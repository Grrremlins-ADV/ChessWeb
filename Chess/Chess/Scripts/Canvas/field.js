window.onload = init;

var field;
var ctxField;

var fieldWidth = 800;
var fieldHeight = 800;

var background = new Image();
background.src = "../Content/pole.jpg";

function init() {
	field = document.getElementById("field");
	ctxField = field.getContext("2d");

	field.width = fieldWidth;
	field.height = fieldHeight;
	drawBg();
}

function drawRectangles() {
	ctxField.fillStyle = "#f0f";
	for (var i = 0; i < 8; i++) {
		for (var j = 0; j < 8; j++) {
			ctxField.fillRect(10*i, 10*j, 10, 10);
		}
	}
}

function drawBg() {
	ctxField.drawImage(background, 0, 0, 503, 480,
		0, 0, fieldWidth, fieldHeight);
}