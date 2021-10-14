import 'package:flutter/material.dart';
import 'package:flutter_admin/pages/home.dart';
import 'package:flutter_admin/pages/login.dart';

final router = {
  '/': (context) => const Home(),
  '/login': (context) => const Login()
  };

Route? onGenerateRoute(RouteSettings settings) {
  final String? name = settings.name;
  final Function? pageContentBuilder = router[name];
  if (pageContentBuilder != null) {
    if (settings.arguments != null) {
      final Route route = MaterialPageRoute(
          builder: (context) =>
              pageContentBuilder(context, arguments: settings.arguments));
      return route;
    } else {
      final Route route =
          MaterialPageRoute(builder: (context) => pageContentBuilder(context));
      return route;
    }
  }
  return null;
}