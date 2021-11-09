import 'package:flutter/material.dart';
import 'package:flutter_blog/controllers/menu_controller.dart';
import 'package:get/get.dart';

import '../../../constants.dart';

class WebMenu extends StatelessWidget {
  final MenuController _controller = Get.put(MenuController());

  WebMenu({
    Key? key,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Obx(
      () => Row(
        children: List.generate(
            _controller.menuItems.length,
            (index) => WebMenuItem(
                isActive: index == _controller.selectedIndex,
                text: _controller.menuItems[index],
                press: () => _controller.setMenuIndex(index))),
      ),
    );
  }
}

class WebMenuItem extends StatefulWidget {
  const WebMenuItem(
      {Key? key,
      required this.isActive,
      required this.text,
      required this.press})
      : super(key: key);

  final bool isActive;
  final String text;
  final VoidCallback press;

  @override
  State<WebMenuItem> createState() => _WebMenuItemState();
}

class _WebMenuItemState extends State<WebMenuItem> {
  bool _isHover = false;

  Color _borderColor() {
    if (widget.isActive) {
      return kPrimaryColor;
    } else if (!widget.isActive & _isHover) {
      return kPrimaryColor.withOpacity(0.4);
    }
    return Colors.transparent;
  }

  @override
  Widget build(BuildContext context) {
    return InkWell(
      onTap: widget.press,
      onHover: (value) {
        setState(() {
          _isHover = value;
        });
      },
      child: Container(
        margin: const EdgeInsets.symmetric(horizontal: kDefaultPadding),
        padding: const EdgeInsets.symmetric(vertical: kDefaultPadding / 2),
        decoration: BoxDecoration(
          border: Border(
            bottom: BorderSide(color: _borderColor(), width: 3),
          ),
        ),
        child: Text(
          widget.text,
          style: TextStyle(
              color: Colors.white,
              fontWeight:
                  widget.isActive ? FontWeight.w600 : FontWeight.normal),
        ),
      ),
    );
  }
}
