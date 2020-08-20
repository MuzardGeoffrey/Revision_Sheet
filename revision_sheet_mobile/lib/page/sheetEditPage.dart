
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:revision_sheet_mobile/page/chapterPage.dart';
import 'package:revision_sheet_mobile/page/coursePage.dart';
import 'package:revision_sheet_mobile/page/sheetPage.dart';

class SheetEditPage extends StatefulWidget {
  SheetEditPage({Key key, @required this.title, @required this.content}) : super(key: key);

  final String content;
  final String title;

    @override
  _SheetEditPage createState() => _SheetEditPage();
}
  
class _SheetEditPage extends State<SheetEditPage> {
  
  final TextEditingController _contentController = new TextEditingController();

  @override
  void initState(){
    super.initState();
    _contentController.text = widget.content;
  }

  
  Widget build(BuildContext context){
    return Scaffold(
      appBar: AppBar(
        title: Text(widget.title),
      ),
      body: Column(
        children: [
          Container(
            width: double.infinity,
            child: Padding(
              padding: EdgeInsets.all(8.0),
              child: TextField(
                onChanged: (String s) {
                  courses[courseSelect].chapterList[chapterSelect].sheets[sheetSelect].content = s;
                },
                decoration: InputDecoration.collapsed(hintText: "Ecriver votre note ici"),
                maxLines: null,
                keyboardType: TextInputType.multiline,
                controller: _contentController,
              ),
            ),
          ),
        ],
      )
    );
  }

}