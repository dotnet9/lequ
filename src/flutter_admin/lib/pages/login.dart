
import 'package:flutter/material.dart';
import 'package:flutter_admin/generated/l10n.dart';
import 'package:shared_preferences/shared_preferences.dart';

import 'home.dart';

class Login extends StatefulWidget {
  const Login({Key? key}) : super(key: key);

  @override
  State<Login> createState() => _LoginState();
}

class _LoginState extends State<Login> {
  final _userNameKey = 'name';
  final _userPwdKey = 'pwd';
  final _userName = TextEditingController(); // user name
  final _userPwd = TextEditingController(); // password
  final GlobalKey _globalKey =
      GlobalKey<FormState>(); // use to check input field is empty

  bool _login() {
    if (_userName.text == 'admin' && _userPwd.text == '123456') {
      Navigator.of(context).pushAndRemoveUntil(
          MaterialPageRoute(builder: (context) => const Home()),
          (route) => route == null);
      return true;
    }

    showDialog(
        context: context,
        builder: (context) {
          return AlertDialog(
            title: const Text("Prompts"),
            content: const Text('username or password fail, please check!'),
            actions: [
              TextButton(
                  onPressed: () {
                    Navigator.of(context).pop(true);
                  },
                  child: const Text('ok'))
            ],
          );
        });
    return false;
  }

  void _saveLoginInfo() async {
    SharedPreferences preferences = await SharedPreferences.getInstance();
    preferences.setString(_userNameKey, _userName.text);
    preferences.setString(_userPwdKey, _userPwd.text);
  }

  void _getLoginInfo() async {
    SharedPreferences preferences = await SharedPreferences.getInstance();
    _userName.text = preferences.getString(_userNameKey) ?? '';
    _userPwd.text = preferences.getString(_userPwdKey) ?? '';
  }

  @override
  void initState() {
    super.initState();
    _getLoginInfo();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(S.of(context).appTitle),
      ),
      body: Center(
        child: Form(
          key: _globalKey,
          autovalidateMode: AutovalidateMode.always,
          child: Column(
            children: [
              TextFormField(
                controller: _userName,
                decoration: const InputDecoration(
                    label: Text('user name'),
                    hintText: 'input your user name',
                    icon: Icon(Icons.person)),
                validator: (v) {
                  return (v != null && v.isNotEmpty)
                      ? null
                      : 'user name cannot be empty';
                },
              ),
              TextFormField(
                controller: _userPwd,
                decoration: const InputDecoration(
                    label: Text('password'),
                    hintText: 'input your password',
                    icon: Icon(Icons.lock)),
                validator: (v) {
                  return (v != null && v.length > 5)
                      ? null
                      : 'The length of the password must be long than 6';
                },
                obscureText: true,
              ),
              const Padding(padding: EdgeInsets.only(top: 20)),
              SizedBox(
                width: 120,
                height: 50,
                child: ElevatedButton(
                  onPressed: () {
                    if ((_globalKey.currentState as FormState).validate()) {
                      _login();
                      _saveLoginInfo();
                    }
                  },
                  child: const Text(
                    'login',
                    style: TextStyle(color: Colors.white),
                  ),
                ),
              )
            ],
          ),
        ),
      ),
    );
  }
}
