import 'package:flutter/material.dart';
import 'package:revision_sheet_mobile/Model/Chapter.dart';
import 'package:revision_sheet_mobile/page/sheetPage.dart';

class ChapterPage extends StatefulWidget  {
  ChapterPage({Key key, this.title, this.chapters}) : super(key: key);

    final String title;
    final List<Chapter> chapters;

  @override
  _ChapterPage createState() => _ChapterPage();
}

  int chapterSelect;

class _ChapterPage extends State<ChapterPage> {

  final List<Color> _listColors = [
    Colors.blue[200], 
    Colors.red[200], 
    Colors.green[200],
    Colors.purple[200],
    Colors.orange[200],
  ];
  


  Widget build(BuildContext context){
    return Scaffold(
      appBar: AppBar(
        title: Text(widget.title),
      ),
      body: _buildChapters(),
      );
  }
  
  Widget _buildChapters() {

    _listColors.shuffle();
    
    return GridView.builder(
      itemCount: widget.chapters.length,
      gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(crossAxisCount: 2),
      itemBuilder: (context, i) {

        int index = i%5;

        return Container(
          padding: EdgeInsets.all(10),
          child: RaisedButton(
            color: _listColors[index],
            child: Text(widget.chapters[i].name),
            onPressed: () { 
              chapterSelect = i;

                Navigator.push(
                context, 
                new MaterialPageRoute(
                  builder: (context)=> new SheetPage(
                    sheets: widget.chapters[i].sheets, 
                    title: widget.chapters[i].name,
                  )
                )
              );
            }
          ),
        );
      }      
    );
  }
  
}