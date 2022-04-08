





document.getElementById("send").onclick = function() {

    
    for (let i = 5; i > 3; i--) {
        getFilm(i)
    }
    
    
}
function buildRow(json) {

    var tbody = document.getElementById("table").getElementsByTagName("tbody")[0];
    var row = document.createElement("tr");
    var td1 = document.createElement("td");
    td1.appendChild(document.createTextNode(`${json.name}`));
    var td2 = document.createElement("td");
    td2.innerHTML = `<a href= ${json.link}>Ссылка</a>`;
    var td3 = document.createElement("td");
    td3.appendChild(document.createTextNode(`${json.dateCreate}`));
    var td4 = document.createElement("td");
    td4.appendChild(document.createTextNode(`${json.review}`));

    row.appendChild(td1);
    row.appendChild(td2);
    row.appendChild(td3);
    row.appendChild(td4);
    tbody.appendChild(row);
}
function getFilm(filmId) {
    var x = new XMLHttpRequest();
    let jsonResponse

    x.open("GET", `https://localhost:7140/getFilm?FilmId=${filmId}`, true);
    x.onload = () => {

        jsonResponse = JSON.parse(x.responseText);
        console.log(jsonResponse)
        buildRow(jsonResponse)

    };

    x.send();
}