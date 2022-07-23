window.onload = function() {
    var fileInput = document.getElementById('file-input');
    var buttonSend = document.getElementById('transfer');
    var separatorSelector = document.getElementById('separator');
    var saveButton = document.getElementById('save');

    fileInput.addEventListener('change', function(e) {
        file = fileInput.files[0];
        loadFile(file);

        /* Переписываем и тип и значение, ибо в разных браузерах иногда не работает */
        fileInput.type = "text";
        fileInput.type = "file";
        fileInput.value = "";
    });

    buttonSend.addEventListener('click', sendData);

    separatorSelector.addEventListener('change', function(e) {
        var text = document.getElementById('storage-text').innerHTML;
        var words = splitText(text);
        appendToTable('leftList', words);
    });

    saveButton.addEventListener('click', function(e) {
        var text = document.getElementById('storage-sorted-text').innerHTML;
        var words = splitText(text);

        saveFile(listToString(words));
    });
}