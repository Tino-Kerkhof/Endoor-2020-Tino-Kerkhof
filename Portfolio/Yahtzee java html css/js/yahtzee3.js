//menu responsive bar
$(document).ready(function () {
  $('.menu-toggle').click(function () {
    $('nav').toggleClass('active')
  })
})

/*  RESULTERENDE CLASSEN: 
    'noScore': Als er geen score in het scorevakje staat.
    'maybeScore': Als er punten te behalen zijn in dat scorevakje.
    'lockedScore': als je al punten hebt staan op dat vakje.
    'yahtzeeBonus': voor als je een 2e keer Yahtzee gooit.
    'hasYahtzeeBonus': voor als je de yahtzeeBonus hebt ingevuld.
    'hasUpperBonus': voor als je de upper bonus behaald hebt.
    'unlockedDice': voor als de speler de die wilt rollen.
    'lockedDice': voor als de speler de die wilt vastzetten.

    BENODIGDE IDS voor scoreblokjes: 
    "ones", "twos", "threes", "fours", "fives", "sixes", "threeOfAKind", "fourOfAKind",
    "fullHouse", "smallStraight", "largeStraight", "yahtzee", "chance"
    "subtotalTop", "bonusTop", "totalTop", "totalBottom", "grandTotal"

    BENODIGDE IDS voor buttons:
    "newGame": voor een nieuw spel.
    "roll": voor het rollen van de dobbelstenen.

    BENODIGDE IDS voor het vastzetten van de dobbelstenen:
    "die0" - "die4"
*/

///////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////
// initializations
//dice
var dice = new Array();
var dice1; var dice2; var dice3; var dice4; var dice5;
var lockDie = [false, false, false, false, false];
var turn = 1; var rollNumber = 0;

// scores
/* The score types have these indexes in the arrays:
    0: ones
    1: twos
    2: threes 
    3: fours
    4: fives
    5: sixes 
    6: three of a kind
    7: four of a kind
    8: full house
    9: small straight 
    10: large straight
    11: Yahtzee
    12: chance
    13: YahtzeeBonus

    totals:
    0: subtotal top
    1: bonus top
    2: total top
    3: total bottom
    4: grand total
*/
var scores = new Int32Array(14);
scores.fill(0, 0, scores.length);

var rollScores = new Int32Array(14);
rollScores.fill(0, 0, rollScores.length);

var totalScore = new Int32Array(5);
totalScore.fill(0, 0, totalScore.length);

var hasScores = new Array(14);
hasScores.fill(false, 0, hasScores.length);

var scoresId = ["ones", "twos", "threes", "fours", "fives", "sixes", "threeOfAKind", "fourOfAKind",
  "fullHouse", "smallStraight", "largeStraight", "yahtzee", "chance", "yahtzeeBonus"];
var totalsId = ["subtotalTop", "bonusTop", "totalTop", "totalBottom", "grandTotal"];

///////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////
// buttons
// document.querySelector("#newGame button").addEventListener("click", NewGame);
document.querySelector("#roll-btn").addEventListener("click", nextRoll);

// scoresheet
for (i = 0; i < scores.length; i++) {
  // document.getElementById(scoresId[i]).addEventListener("click", function () { lockScore(i) }); // vervalt, gekozen voor refresh
  document.getElementById(scoresId[i]).setAttribute('onclick', 'lockScore(' + i + ');');
}

// lock dice
document.getElementById('die0').setAttribute('onclick', 'LockDice(0);');
document.getElementById('die1').setAttribute('onclick', 'LockDice(1);');
document.getElementById('die2').setAttribute('onclick', 'LockDice(2);');
document.getElementById('die3').setAttribute('onclick', 'LockDice(3);');
document.getElementById('die4').setAttribute('onclick', 'LockDice(4);');


///////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////
// dice

function nextRoll() {
  if (turn <= 13) {
    if (rollNumber < 3) {
      rollDice();
      rollNumber++;
      RollScoresFill();
      showRollResult();
    }
  }
}

function rollDice() {
  dice.splice(0, dice.length);
  if (!lockDie[0]) { die1 = RollDie(); }
  if (!lockDie[1]) { die2 = RollDie(); }
  if (!lockDie[2]) { die3 = RollDie(); }
  if (!lockDie[3]) { die4 = RollDie(); }
  if (!lockDie[4]) { die5 = RollDie(); }
  dice.push(die1); dice.push(die2); dice.push(die3); dice.push(die4); dice.push(die5);
  dice.sort();
  setImage(0, die1); setImage(1, die2); setImage(2, die3); setImage(3, die4); setImage(4, die5);
}

// deze functie geeft een plaatje weer van een dobbelsteenwaarde (diceValue) op de aangegeven plaats (num)
function setImage(num, diceValue) {
  return document.querySelectorAll('.dice')[num].setAttribute('src', 'dice/dice' + diceValue + '.png');
}

// deze functie genereerd een willekeurig getal tussen een minimum (min) en een maximum (max) cijfer
function GetNewRandom(min, max) {
  return Math.floor(Math.random() * (max - min + 1)) + min;
}

// deze functie vraagt een willekeurig getal tussen 1 en 6 (voor een d6)
function RollDie() {
  return GetNewRandom(1, 6);
}

function LockDice(i) {
  if (rollNumber > 0) {
    if (lockDie[i]) {
      lockDie[i] = false;
      document.getElementById('die' + i).setAttribute('class', 'inline dice unlockedDice');
    } else {
      lockDie[i] = true;
      document.getElementById('die' + i).setAttribute('class', 'inline dice lockedDice');
    };
  }
}

///////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////
// laat het resultaat zien en schrijf het in het scoreblad.
// Laat resultaat van de rol zien.
function showRollResult() {
  for (var i = 0; i < rollScores.length; i++) {
    if (!hasScores[i]) {
      if (rollScores[i] != 0) {
        document.getElementById(scoresId[i]).setAttribute('class', 'scoreBlokje maybeScore');
        document.getElementById(scoresId[i]).innerHTML = rollScores[i];
      } else {
        NoResult(scoresId[i])
      }

      // Yahtzee bonus special!!
      if(hasScores[11] && IsYahtzee()) {
        document.getElementById(scoresId[13]).setAttribute('class', 'scoreBlokje yahtzeeBonus');
      }
    }
  }
}

// schrijf resultaat naar scoreblad
function lockScore(scoreIndex) {
  var i = scoreIndex;
  if (!hasScores[i] && rollNumber != 0) {
    document.getElementById(scoresId[i]).setAttribute('class', 'scoreBlokje lockedScore');
    if (rollScores[i] != 0) {
      document.getElementById(scoresId[i]).innerHTML = rollScores[i];
    } else {
      document.getElementById(scoresId[i]).innerHTML = '-';
    }
    scores[i] = rollScores[i];
    if (i!= 13) {hasScores[i] = true;}
    UpdateTotals();
    showTotalScore();
    NextTurn(i);
  }
}

// laat de totaal scores zien
function showTotalScore() {
  for (i = 0; i < totalScore.length; i++) {
    document.getElementById(totalsId[i]).innerHTML = totalScore[i];
  }
}

///////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////
// resultaat van de roll
function RollScoresFill() {
  rollScores[0] = Numbers(1);
  rollScores[1] = Numbers(2);
  rollScores[2] = Numbers(3);
  rollScores[3] = Numbers(4);
  rollScores[4] = Numbers(5);
  rollScores[5] = Numbers(6);
  rollScores[6] = ThreeOfAKind();
  rollScores[7] = FourOfAKind();
  rollScores[8] = FullHouse();
  rollScores[9] = SmallStraight();
  rollScores[10] = LargeStraight();
  rollScores[11] = Yahtzee();
  rollScores[12] = Chance();
  rollScores[13] = YahtzeeBonus();
}

// update the totals
function UpdateTotals() {
  totalScore[0] = scores[0] + scores[1] + scores[2] + scores[3] + scores[4] + scores[5];
  if (totalScore[0] >= 63) { 
    totalScore[1] = 35; 
    document.getElementById(totalsId[1]).setAttribute('class', 'scoreBlokje hasUpperBonus')
  }
  totalScore[2] = totalScore[0] + totalScore[1];
  totalScore[3] = scores[6] + scores[7] + scores[8] + scores[9] + scores[10] + scores[11] + scores[12];
  totalScore[4] = totalScore[2] + totalScore[3] + scores[13];
}

// deze functie schrijft geeft de waarde van een number-vakje
function Numbers(x) {
  var numberOfNumber = 0;
  for (var i = 0; i < dice.length; i++) {
    if (dice[i] == x) {
      numberOfNumber++;
    }
  }
  return numberOfNumber * x;
}

// deze functie geeft het resultaat voor three of a kind
function ThreeOfAKind() {
  if (IsThreeOfAKind()) {
    return SumTotalDice();
  } else {
    return 0;
  }
}

// deze functie geeft het resultaat voor four of a kind
function FourOfAKind() {
  if (IsFourOfAKind()) {
    return SumTotalDice();
  } else {
    return 0;
  }
}

// deze functie geeft het resultaat voor full house
function FullHouse() {
  if (IsFullHouse()) {
    return 25;
  } else {
    return 0;
  }
}

// deze functie geeft het resultaat voor kleine straat
function SmallStraight() {
  if (IsSmallStraight()) {
    return 30;
  } else {
    return 0;
  }
}

// deze functie geeft het resultaat voor groote straat
function LargeStraight() {
  if (IsLargeStraight()) {
    return 40;
  } else {
    return 0;
  }
}

// deze functie geeft het resultaat voor Yathzee
function Yahtzee() {
  if (IsYahtzee()) {
    return 50;
  } else {
    return 0;
  }
}

function YahtzeeBonus() {
  if (IsYahtzee() && scores[11] > 0) {
    return scores[13] + 100;
  } else {
    return scores[13];
  }
}

// deze functie geeft het resultaat voor Chance
function Chance() {
  return SumTotalDice()
}

function SumTotalDice() {
  return dice[0] + dice[1] + dice[2] + dice[3] + dice[4];
}

///////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////
//logica van de scores

// deze functie kijkt of het de worp (dice (gesorteerd)) een three of a kind is.
function IsThreeOfAKind() {
  if (dice[0] == dice[1] && dice[0] == dice[2] ||
    dice[1] == dice[2] && dice[1] == dice[3] ||
    dice[2] == dice[3] && dice[2] == dice[4]) {
    return true;
  }
  return false;
}

// deze functie kijkt of het de worp (dice (gesorteerd)) een four of a kind is.
function IsFourOfAKind() {
  if (dice[0] == dice[1] && dice[0] == dice[2] && dice[0] == dice[3] ||
    dice[1] == dice[2] && dice[1] == dice[3] && dice[1] == dice[4]) {
    return true;
  }
  return false;
}

// deze functie kijkt of het de worp (dice (gesorteerd)) een full house is.
function IsFullHouse() {
  if (dice[0] == dice[1] && dice[0] == dice[2] && dice[3] == dice[4] ||
    dice[2] == dice[3] && dice[2] == dice[4] && dice[0] == dice[1]) {
    return true;
  }
  return false;
}

// deze functie kijkt of het de worp (dice (gesorteerd)) een kleine straat is.
function IsSmallStraight() {
  if (dice.includes(1) && dice.includes(2) && dice.includes(3) && dice.includes(4) ||
    dice.includes(2) && dice.includes(3) && dice.includes(4) && dice.includes(5) ||
    dice.includes(3) && dice.includes(4) && dice.includes(5) && dice.includes(6)) {
    return true;
  }
  return false;
}

// deze functie kijkt of het de worp (dice (gesorteerd)) een groote straat is.
function IsLargeStraight() {
  if (dice.includes(1) && dice.includes(2) && dice.includes(3) && dice.includes(4) && dice.includes(5) ||
    dice.includes(2) && dice.includes(3) && dice.includes(4) && dice.includes(5) && dice.includes(6)) {
    return true;
  }
  return false;
}

// deze functie kijkt of het de worp (dice (gesorteerd)) een Yahtzee is.
function IsYahtzee() {
  if (dice[0] == dice[1] && dice[0] == dice[2] && dice[0] == dice[3] && dice[0] == dice[4]) {
    return true;
  }
  return false;
}

///////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////
// cleanup

function NewGame() {
  hasScores.fill(false, 0, hasScores.length);
  scores.fill(0, 0, scores.length);
  totalScore.fill(0, 0, totalScore.length);
  UnlockDice();
  turn = 1;
  rollNumber = 0;
  for (i = 0; i < scoresId.length; i++) { NoResult(scoresId[i]); }
  for (i = 0; i < totalsId.length; i++) { NoResult(totalsId[i]); }
}

function NextTurn(lockedScoreIndex) {
  if (lockedScoreIndex !=13) { turn++; }
  rollNumber = 0;
  UnlockDice();
  for (i = 0; i < scoresId.length-1; i++) {
    if (!hasScores[i]) { NoResult(scoresId[i]); }
  }
  if (scores[13] == 0) { NoResult(scoresId[13]); }
  else if (scores[13] > 0) {
    document.getElementById(scoresId[13]).setAttribute('class', 'scoreBlokje hasYahtzeeBonus');
    document.getElementById(scoresId[13]).innerHTML = scores[13];
  }
}

function UnlockDice() {
  lockDie = [false, false, false, false, false];
  for (i = 0; i < lockDie.length; i++) {
    document.getElementById('die' + i).setAttribute('class', 'inline dice unlockedDice');
  }
}

function NoResult(ElementId) {
  document.getElementById(ElementId).setAttribute('class', 'scoreBlokje noScore');
  document.getElementById(ElementId).innerHTML = "";
}

//Fullscreen

function toggleFullScreen() {
  if ((document.fullScreenElement && document.fullScreenElement !== null) ||    
   (!document.mozFullScreen && !document.webkitIsFullScreen)) {
    if (document.documentElement.requestFullScreen) {  
      document.documentElement.requestFullScreen();  
    } else if (document.documentElement.mozRequestFullScreen) {  
      document.documentElement.mozRequestFullScreen();  
    } else if (document.documentElement.webkitRequestFullScreen) {  
      document.documentElement.webkitRequestFullScreen(Element.ALLOW_KEYBOARD_INPUT);  
    }  
  } else {  
    if (document.cancelFullScreen) {  
      document.cancelFullScreen();  
    } else if (document.mozCancelFullScreen) {  
      document.mozCancelFullScreen();  
    } else if (document.webkitCancelFullScreen) {  
      document.webkitCancelFullScreen();  
    }  
  }  
}