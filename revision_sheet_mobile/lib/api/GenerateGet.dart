import 'package:revision_sheet_mobile/Model/Chapter.dart';
import 'package:revision_sheet_mobile/Model/Course.dart';
import 'package:faker/faker.dart';
import 'package:revision_sheet_mobile/Model/Sheet.dart';

class GenerateData{

  List<Course> generateDataCourse(int tailleList) {
    List<Course> coursedata = new List(tailleList);

    for (var i = 0; i < tailleList; i++) {

      Course course = new Course(
        id: i,
        name: faker.person.firstName(), 
        chapterList: generateDataChapter(random.integer(7,min: 2))
      );

      coursedata[i] = course;
    }

    return coursedata;
  }

  List<Chapter> generateDataChapter(int tailleList) {
    List<Chapter> chapterData = new List(tailleList);

    for (var i = 0; i < tailleList; i++) {
      Chapter chapter = new Chapter(
        id: i, 
        name: faker.job.title(), 
        sheets: generateDataSheet(random.integer(10,min: 3))
      );
    
      chapterData[i] = chapter;
    }
    return chapterData;
  }
  
  List<Sheet> generateDataSheet(int tailleList) {
    
    List<Sheet> sheetData = new List(tailleList);

    for (var i = 0; i < tailleList; i++) {
      
      Sheet sheet = new Sheet(id: i, title: faker.food.restaurant(),content: faker.lorem.sentence());
      sheetData[i] = sheet;
    }
    return sheetData;
  }

}