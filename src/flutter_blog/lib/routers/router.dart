import 'package:flutter/material.dart';
import 'package:flutter_blog/routers/routes.dart';
import 'package:flutter_blog/screens/main/main_screen.dart';
import 'package:flutter_blog/screens/posts/post.dart';

final router = {
  homeRoute: (context) => MainScreen(),
  postRoute: (context) => Post()
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