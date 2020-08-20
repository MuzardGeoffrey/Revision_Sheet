import 'dart:convert';

User userFromJson(String str) => User.fromJson(json.decode(str));

String userToJson(User data) => json.encode(data.toJon());

class User {
  int id;
  String login;
  String password;
  
  User({
    this.id,
    this.login,
    this.password
  });

  factory User.fromJson(Map<String,dynamic> json) => User(
    id: json["id"],
    login: json["login"],
    password: json["password"],
  );

  Map<String, dynamic> toJon() => {
    "id": id,
    "login": login,
    "password": password,
  };

}