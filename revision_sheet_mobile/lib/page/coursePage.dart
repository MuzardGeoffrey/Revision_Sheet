import 'package:faker/faker.dart';
import 'package:flutter/material.dart';
import 'package:revision_sheet_mobile/Model/Course.dart';
import 'package:revision_sheet_mobile/api/GenerateGet.dart';
//import 'package:revision_sheet_mobile/api/courses/get_courses.dart';
import 'package:revision_sheet_mobile/page/chapterPage.dart';

class CoursePage extends StatefulWidget {
  CoursePage({Key key, this.title}) : super(key: key);

  final String title;

  @override
  _CoursePageState createState() => _CoursePageState();
}

  List<Course> courses;
  int courseSelect;

class _CoursePageState extends State<CoursePage> {

  @override
  void initState(){
    super.initState();
    GenerateData data = new GenerateData();
    courses = data.generateDataCourse(random.integer(13,min: 5));
  }

  Widget build(BuildContext context){
    return Scaffold(
      appBar: AppBar(
        title: Text('Cours'),
      ),
      body: _buildCourses()
    );
  }
  
  Widget _buildCourses() {

    final List<Color> _listColors = [
    Colors.blue[200], 
    Colors.red[200], 
    Colors.green[200],
    Colors.purple[200],
    Colors.orange[200],
    ];

    _listColors.shuffle();

    return GridView.builder(
      itemCount: courses.length,
      gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(crossAxisCount: 2),
      itemBuilder: (context, i) {

        int index = i%5;

        return Container(
          padding: EdgeInsets.all(10),
          child: RaisedButton(
            color: _listColors[index],
            child: Text(courses[i].name),
            onPressed:  () {
              courseSelect=i;

              Navigator.push(
                context, 
                new MaterialPageRoute(
                  builder: (context)=> new ChapterPage(
                    chapters: courses[i].chapterList,
                    title: courses[i].name
                  )
                )
              );
            }
          )
        );
      }
    );
  }
}