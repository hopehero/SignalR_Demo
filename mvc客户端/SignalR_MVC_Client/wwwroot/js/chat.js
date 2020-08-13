"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("http://localhost:5000/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;
//这个可以不一致
connection.on("toall", function (user, message,test) {
    var msg = message;
    var encodedMsg = user + " says " + msg + "\n来源是" + test;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    //和服务器必须一致
    connection.invoke("sendall", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});