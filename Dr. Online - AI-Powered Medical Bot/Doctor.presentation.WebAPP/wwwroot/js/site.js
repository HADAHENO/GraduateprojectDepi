var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

// Listen for "ReceiveMessage" (ensure the method name matches the one in the backend Hub)
connection.on("ReceiveMessage", function (fromUser, message) {
    var msg = fromUser + ": " + message;
    var li = document.createElement("li");
    li.textContent = msg;
    $("#list").prepend(li);  // Prepend the message to the list
});

// Start the connection and handle any errors
connection.start().catch(function (err) {
    return console.error(err.toString());
});

// Handle the Send button click event
$("#btnSend").on("click", function () {
    var fromUser = $("#txtUser").val();
    var message = $("#txtMessage").val();

    // Invoke the SendMessage method on the server-side hub
    connection.invoke("SendMessage", fromUser, message).catch(function (err) {
        return console.error(err.toString());
    });
});
