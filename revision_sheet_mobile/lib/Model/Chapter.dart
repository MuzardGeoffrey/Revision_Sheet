import 'Sheet.dart';
import 'dart:convert';

Chapter chapterFromJson(String str) => Chapter.fromJson(json.decode(str));

String chapterToJson(Chapter data) => json.encode(data.toJon());

class Chapter {
  Chapter({
    this.id,
    this.name,
    this.sheets
  });

  int id;
  String name;
  List<Sheet> sheets;

  factory Chapter.fromJson(Map<String,dynamic> json) => Chapter(
    id: json["id"],
    name: json["name"],
    sheets: json["sheets"],
  );

  Map<String, dynamic> toJon() => {
    "id": id,
    "name": name,
    "sheets": sheets,
  };

}