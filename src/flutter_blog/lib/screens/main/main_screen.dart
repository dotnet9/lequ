import 'package:flutter/material.dart';
import 'package:flutter_blog/constants.dart';
import 'package:flutter_blog/controllers/menu_controller.dart';
import 'package:flutter_blog/screens/home/home_screen.dart';
import 'package:flutter_blog/screens/main/components/side_menu.dart';
import 'package:get/get.dart';
import 'components/header.dart';

class MainScreen extends StatelessWidget {
  final MenuController _controller = Get.put(MenuController());
  MainScreen({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      key: _controller.scaffoldkey,
      drawer: SideMenu(),
      body: SingleChildScrollView(
        child: Column(
          children: [
            Header(),
            Container(
              padding: const EdgeInsets.all(kDefaultPadding),
              constraints: const BoxConstraints(maxWidth: kMaxWidth),
              child: const SafeArea(child: HomeScreen()),
            )
          ],
        ),
      ),
    );
  }
}
