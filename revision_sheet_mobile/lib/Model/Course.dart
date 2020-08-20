import 'Chapter.dart';
import 'dart:convert';

Course courseFromJson(String str) => Course.fromJson(json.decode(str));

String courseToJson(Course data) => json.encode(data.toJon());

class Course {
  Course({
    this.id,
    this.name,
    this.chapterList
  });

  int id;
  String name;
  List<Chapter> chapterList;

  factory Course.fromJson(Map<String,dynamic> json) => Course(
    id: json["id"],
    name: json["name"],
    chapterList: json["chapterList"],
  );

  Map<String, dynamic> toJon() => {
    "id": id,
    "name": name,
    "chapterList": chapterList,
  };
}