function toonPrompt() {
    var code = prompt('Vul uw promotiecode in', 'uw code');
    var tekst = 'De code die u invulde was: ' + code;
    document.getElementById("uitvoerTekst").innerHTML = tekst;
}

function VoorwaardelijkeOperator() {
    var antwoord = prompt('Wat is 20 + 60', '0');
    if (antwoord == 80) {
        var tekst = 'Prima, ga zo door!';
    } else {
        var tekst = 'Jammer, volgende keer beter';
    }

    document.getElementById("uitvoerTekst").innerHTML = tekst;
}
function RandomNumber(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}
function ZelfdeRandomNumber() {
    var value = RandomNumber(1, 10);
    var antwoord = prompt('Kies een getal tussen 1 en 10.', '1');
    if (antwoord == value) {
        var tekst = 'Prima, ga zo door!';
    } else {
        var tekst = 'Jammer, volgende keer beter';
    }

    document.getElementById("uitvoerTekst").innerHTML = tekst;
}

function Rekenmachine() {
    var getal1 = parseInt(document.getElementById("getal1").value);
    var getal2 = parseInt(document.getElementById("getal2").value);
    var operation = document.getElementById("operation").value;
    if (operation == 'maal') {
        var uitkomst = getal1 * getal2;
        uitkomst = 'Uitkomst = ' + uitkomst;
    }
    else if (operation == 'delen door') {
        if (getal2 == 0) {
            var uitkomst = 'Kan niet delen door nul.';
        }
        else {
            var uitkomst = getal1 / getal2;
            uitkomst = 'Uitkomst = ' + uitkomst;
        }
    }
    else if (operation == 'plus') {
        var uitkomst = getal1 + getal2;
        uitkomst = 'Uitkomst = ' + uitkomst;
    }
    else if (operation == 'min') {
        var uitkomst = getal1 - getal2;
        uitkomst = 'Uitkomst = ' + uitkomst;
    }
    else {
        var uitkomst = 'Ongeldige invoer.'
    }

    if (uitkomst == 'Uitkomst = NaN') {
        uitkomst = 'Ongeldige invoer.'
    }
    document.getElementById("uitvoerTekst").innerHTML = uitkomst;
}

function VandaagIsHet() {
    var vandaag = new Date();
    var weekdagVandaag = vandaag.getDay();
    var weekdagen = ['zondag',
        'maandag',
        'dinsdag',
        'woensdag',
        'donderdag',
        'vrijdag',
        'zaterdag'];
    var uitvoerTekst = 'Vandaag is het ' + weekdagen[weekdagVandaag];
    document.getElementById("VandaagDeDag").innerHTML = uitvoerTekst;
}

function SpreekwoordVanVandaag() {
    var vandaag = new Date();
    var weekdagVandaag = vandaag.getDay();
    var spreekwoorden = ['Eigen haard is goud waard',
        'Haastige spoed is zelden goed',
        'Beter laat dan nooit',
        'Wie het laatst lacht, lacht het best',
        'De morgenstond heeft goud in de mond',
        'Zoals het klokje thuis tikt, tikt het nergens',
        'Oost west, thuis best'];
    var uitvoerTekst = 'Tip van de dag: ' + spreekwoorden[weekdagVandaag];
    document.getElementById("Spreekwoord").innerHTML = uitvoerTekst;
}

function AapNootMies() {
    var lezen = ['aap', 'noot', 'Mies'];
    lezen.push('Wim'); lezen.push('zus'); lezen.push('Jet');
    for (i = 0; i < lezen.length; i++) {
        document.getElementById("uitvoerTekst").innerHTML += (lezen[i] + ', ');
    }
}

function DrieGetallen() {
    var drieGetallen = [parseInt(prompt('Voer een getal in', '0')),
        parseInt(prompt('Voer een getal in', '0')),
        parseInt(prompt('Voer een getal in', '0'))];
    document.getElementById("uitvoerTekst").innerHTML =
        'Som van de ingevoerde getallen is: ' + (drieGetallen[0] + drieGetallen[1] + drieGetallen[2]);
}

function Yatzhee() {
    var rolls = [RandomNumber(1,6), RandomNumber(1,6), RandomNumber(1,6), RandomNumber(1,6), RandomNumber(1,6)];
    var total = rolls[0] + rolls[1] + rolls[2] + rolls[3] + rolls[4];
    document.getElementById("uitvoerTekst").innerHTML = 'Totaal: ' + total;
    document.getElementById("dice").innerHTML = 
    'Worp: ' + rolls[0] + ', ' + rolls[1] + ', ' + rolls[2] + ', ' + rolls[3] + ', ' + rolls[4];
}