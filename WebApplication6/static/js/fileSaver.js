function saveFile(text) {
    if (text == "") {
        return
    }

    var a = document.createElement("a");
    var file = new Blob([text], { type: 'text/plain' });
    a.href = URL.createObjectURL(file);
    a.download = "result.txt";
    a.click();
}