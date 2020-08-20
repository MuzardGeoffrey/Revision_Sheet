import 'package:flutter/material.dart';
import 'package:revision_sheet_mobile/Model/Sheet.dart';
import 'package:revision_sheet_mobile/page/sheetEditPage.dart';


int sheetSelect;


class SheetPage extends StatelessWidget {
  SheetPage({Key key, @required this.title, @required this.sheets}) : super(key: key);

  final String title;
  final List<Sheet> sheets;
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
        title: Text(title),
      ),
      body: _buildSheets(),
      );
  }
  
  Widget _buildSheets() {

        
    _listColors.shuffle();

    return GridView.builder(
      itemCount: sheets.length,
      gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(crossAxisCount: 2),
      itemBuilder: (context, i) {

        int index = i%5;

        return Container(
          padding: EdgeInsets.all(10),
          child: RaisedButton(
            color: _listColors[index],
            child: Text(sheets[i].title),
            onPressed: () { 
              sheetSelect = i;
              
              Navigator.push(
                context, 
                new MaterialPageRoute(
                  builder: (context) => new SheetEditPage(
                    content: sheets[i].content,
                    title: sheets[i].title,)
                )
              );
            }
          )
        );
      }      
    );
  }
}