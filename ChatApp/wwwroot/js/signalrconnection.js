const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chathub")
    .configureLogging(signalR.LogLevel.Information)
    .build();

connection.start()
    .then(() => {
        console.log("Connection started successfully.");
    })
    .catch((err) => {
        console.error(`Error starting connection: ${err}`);
    });

connection.on("ReceiveMessage", function (fullName, message) {
    var li = document.createElement("li");
    li.textContent = fullName + ": " + message;
    $("#chatListHistory").prepend(li);  // Corrected the id to chatListHistory
});

async function SendMessage() {
    try {
        var fromUser = $("#username").val();
        var msg = $("#Messagelist").val();

        await connection.invoke("SendMessageToAll", fromUser, msg);
        console.log("Message sent successfully.");
    } catch (error) {
        console.error(`Error sending message: ${error}`);
        // Handle the error appropriately (e.g., display an error message to the user)
    }
}
