import 'dart:convert';

Sheet sheetFromJson(String str) => Sheet.fromJson(json.decode(str));

String sheetToJson(Sheet data) => json.encode(data.toJon());

class Sheet {
  Sheet({
    this.id,
    this.title,
    this.content
  });

  int id;
  String title;
  String content;

  factory Sheet.fromJson(Map<String,dynamic> json) => Sheet(
    id: json["id"],
    title: json["title"],
    content: json["content"],
  );

  Map<String, dynamic> toJon() => {
    "id": id,
    "title": title,
    "content": content,
  };
  
}