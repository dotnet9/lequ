import 'package:flutter/material.dart';
import 'package:flutter_blog/controllers/menu_controller.dart';
import 'package:flutter_blog/responsive.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:get/get.dart';

import '../../../constants.dart';
import 'web_menu.dart';
import 'socal.dart';

class Header extends StatelessWidget {
  final MenuController _controller = Get.put(MenuController());

  Header({
    Key? key,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      width: double.infinity,
      color: kDarkBlackColor,
      child: SafeArea(
        child: Column(
          children: [
            Container(
              padding: const EdgeInsets.all(kDefaultPadding),
              constraints: const BoxConstraints(maxWidth: kMaxWidth),
              child: Row(
                children: [
                  if (!Responsive.isDesktop(context))
                    IconButton(
                      onPressed: () {
                        _controller.openOrCloseDrawer();
                      },
                      icon: const Icon(
                        Icons.menu,
                        color: Colors.white,
                      ),
                    ),
                  SvgPicture.asset('assets/icons/logo.svg'),
                  const Spacer(),
                  if (Responsive.isDesktop(context)) WebMenu(),
                  const Spacer(),
                  // Socal
                  const Socal(),
                ],
              ),
            ),
            const SizedBox(height: kDefaultPadding * 2),
            const Text(
              'Welcome to Our Blog',
              style: TextStyle(
                  fontSize: 32,
                  color: Colors.white,
                  fontWeight: FontWeight.bold),
            ),
            const Padding(
              padding: EdgeInsets.symmetric(vertical: kDefaultPadding),
              child: Text(
                'Stay updated with the newest design and development stories, case studies, \nand insights shared by DesignDK Team.',
                textAlign: TextAlign.center,
                style: TextStyle(
                  color: Colors.white,
                  fontFamily: 'Raleway',
                  height: 1.5,
                ),
              ),
            ),
            FittedBox(
              child: TextButton(
                onPressed: () {},
                child: Row(
                  children: const [
                    Text(
                      'Learn More',
                      style: TextStyle(
                        fontWeight: FontWeight.bold,
                        color: Colors.white,
                      ),
                    ),
                    SizedBox(
                      width: kDefaultPadding / 2,
                    ),
                    Icon(
                      Icons.arrow_forward,
                      color: Colors.white,
                    )
                  ],
                ),
              ),
            ),
            if (Responsive.isDesktop(context))
              const SizedBox(
                height: kDefaultPadding,
              )
          ],
        ),
      ),
    );
  }
}
