import 'dart:io';
//import 'package:faker/faker.dart';
//import 'package:http/io_client.dart';
//import 'package:http/http.dart' as http;
//import 'dart:convert';
import 'package:faker/faker.dart';
import 'package:revision_sheet_mobile/Model/Course.dart';
import 'package:revision_sheet_mobile/api/GenerateGet.dart';
//import 'package:revision_sheet_mobile/api/conf_api.dart';

class GetCourses{
  
  List<Course> list;
  HttpClient client = new HttpClient();
  //bool _certificateCheck(X509Certificate cert, String host, int port) => true;

  Future<List<Course>> getPlaces() async{
    /*
    final String apiUrl = apiCourse+"/3";
     var ioClient = new HttpClient()
       ..badCertificateCallback = _certificateCheck;

     IOClient io =  new IOClient(ioClient);
      
      final http.Response response = await http.Client().get(
          apiUrl,
        );

   // final response = await http.get(apiUrl);

    if(response.statusCode == 200){
      final String responseString = response.body;

      var data = json.decode(responseString);

      var rest = data["places"] as List;

      list = rest.map<Course>((json) => Course.fromJson(json)).toList();

      return list;
    }else{
      print(response.statusCode);
      print(response.request);
      print(response.body);
      return null;
    }
    */
    GenerateData generateData = new GenerateData();
    list = generateData.generateDataCourse(random.integer(9,min: 3));
    return list;
  }


}