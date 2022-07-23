function loadFile(file) {
    var storage = document.getElementById('storage-text');
    var reader = new FileReader();
    reader.onload = function(e) {
        var text = reader.result;
        storage.innerHTML = text;

        var words = splitText(text);
        appendToTable('leftList', words);
    }

    reader.readAsText(file);
}

function appendToTable(tableId, words) {
    var table = document.getElementById(tableId);

    var resultHtml = "";
    table.innerHTML = "";
    for (var i = 0; i < words.length; i++) {
        resultHtml += `<div class='line'>${words[i]}</div>`;
    }

    table.innerHTML = resultHtml;
}

function splitText(text) {
    var separator = document.getElementById('separator').value;
    if (separator == "\\n") {
        console.log("Перевод строки");
        return text.split('\n');
    }

    return text.split(separator);
}

function listToString(words) {
    var result = "";
    var separator = document.getElementById('separator').value;

    if (separator == "\\n") {
        separator = "\n";
    }

    for (var i = 0; i < words.length; i++) {
        result += words[i];
        if (i != words.length - 1) {
            result += separator;
        }
    }
    return result;
}