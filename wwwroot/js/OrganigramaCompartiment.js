mermaid.initialize({
    startOnLoad: true,
    securityLevel: 'loose'
});

let params = new URLSearchParams(window.location.search);
console.log(params);
let compartiment = params.get("compartiment");
console.log(compartiment);
let listaAngajati = JSON.parse(decodeURIComponent(params.get("angajati")));
let organigrama = [];
document.getElementById("titluOrganigrama").innerText = "Organigrama " + compartiment;

function formatId(nume) {
    return nume.replace(/\s+/g, '_');
}

function redeseneazaOrganigrama() {
    let diagram = 'graph TD';
    organigrama.forEach(nod => {
        let nodId = formatId(nod.id);
        if (nod.parinte) {
            let parinteId = formatId(organigrama.find(element => element.nume == nod.parinte).id);
            if (nod.relatie) {
                diagram += '\n' + parinteId + '[' + nod.parinte + '] -->|' + nod.relatie + '| ' + nodId + '[' + nod.nume + ']';
            } else {
                diagram += '\n' + parinteId + '[' + nod.parinte + '] --> ' + nodId + '[' + nod.nume + ']';
            }
        } else {
            diagram += '\n' + nodId + '[' + nod.nume + ']';
        }
    });
    let orgChartDiv = document.getElementById('orgChart');
    orgChartDiv.removeAttribute("data-processed");
    orgChartDiv.innerHTML = diagram;
    mermaid.init(undefined, orgChartDiv);
    updateListe();
}

function adaugaNod(nume) {
    nodCurent = nume;
    if (organigrama.length === 0) {
        organigrama.push({ id: nume, nume: nume, parinte: null, relatie: null });
        redeseneazaOrganigrama();
    } else {
        document.getElementById('formular').style.display = 'block';
        let selectAscendent = document.getElementById('ascendent');
        selectAscendent.innerHTML = '';
        organigrama.forEach(nod => {
            let option = document.createElement('option');
            option.value = nod.id;
            option.text = nod.nume;
            selectAscendent.appendChild(option);
        });
    }
}

function submitForm() {
    let ascendent = document.getElementById('ascendent').value;
    let tipRelatie = document.getElementById('tipRelatie').value;

    organigrama.push({ id: nodCurent, nume: nodCurent, parinte: ascendent, relatie: tipRelatie });
    redeseneazaOrganigrama();

    document.getElementById('formular').style.display = 'none';
    document.getElementById('tipRelatie').value = '';
}

function updateListe() {
    let listaPredefinitaDiv = document.getElementById("listaPredefinita");
    listaPredefinitaDiv.innerHTML = "";
    listaAngajati.forEach(nume => {
        if (!organigrama.find(nod => nod.nume === nume)) {
            listaPredefinitaDiv.innerHTML += `<button onclick="adaugaNod('${nume}')">${nume}</button>`;
        }
    });

    let listaModificareDiv = document.getElementById('listaModificare');
    listaModificareDiv.innerHTML = '';
    organigrama.forEach(nod => {
        listaModificareDiv.innerHTML += `<button onclick="modificaNod('${nod.nume}')">${nod.nume}</button>`;
    });
    let listaStergereDiv = document.getElementById('listaStergere');
    listaStergereDiv.innerHTML = '';
    organigrama.forEach(nod => {
        listaStergereDiv.innerHTML += `<button onclick="stergeNod('${nod.nume}')">${nod.nume}</button>`;
    });
}

function modificaNod(nume) {
    nodCurent = nume;
    document.getElementById('formularModificare').style.display = 'block';
}

function submitModificare() {
    let nouaDenumire = document.getElementById('nouaDenumire').value;
    let nod = organigrama.find(nod => nod.nume === nodCurent);

    if (nod) {
        let numeVechi = nod.nume;
        nod.nume = nouaDenumire;
        nod.id = formatId(nouaDenumire);
        ///Updatam copiii
        organigrama.forEach(child => {
            if (child.parinte === numeVechi) {
                child.parinte = nouaDenumire;
            }
        });

        redeseneazaOrganigrama();
    }

    document.getElementById('formularModificare').style.display = 'none';
    document.getElementById('nouaDenumire').value = '';
}

function stergeNod(nume) {
    function stergeSubarbore(nume) {
        organigrama = organigrama.filter(nod => nod.nume !== nume);
        organigrama.filter(nod => nod.parinte === nume).forEach(copil => stergeSubarbore(copil.nume));
    }
    stergeSubarbore(nume);
    redeseneazaOrganigrama();
}

updateListe();