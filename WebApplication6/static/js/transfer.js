async function sendData() {
    var storage = document.getElementById('storage-text');
    var words = storage.innerHTML;
    var separator = document.getElementById('separator').value;

    if (separator == "\\n") {
        separator = "\n";
    }

    sortType = document.getElementById('sort-type').value;
    var response = fetch("https://localhost:7234/transfer", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify({
            sort: sortType,
            word: words,
            separator: separator
        })

    }).then(response => {
        return response.json();
    }).then(data => {
        var result = data.result;
        document.getElementById('storage-sorted-text').innerHTML = result;

        result = splitText(result);
        appendToTable('rightList', result);

    });
}