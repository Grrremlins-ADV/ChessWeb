window.onload = init;

var field;
var ctxField;

var fig;
var ctxFig;

var fieldWidth = 800;
var fieldHeight = 800;

var board = new Image();
board.src = "../Content/board2.jpg";

var p_figure = new Image();
p_figure.src = "../Content/Bishop_White.gif";

function Figure() {
	this.srcX = 0;
	this.srcY = 0;
	this.drawX = 45;
	this.drawY = 45;
	this.width = 48;
	this.height = 48;
}

Figure.prototype.draw = function ()
{
	ctxField.drawImage(p_figure, this.srcX, this.srcY, this.width, this.height,
		this.drawX, this.drawY, 89, 89);
	console.log("kjsjdfkjf");
}

function init() {
	field = document.getElementById("field");
	ctxField = field.getContext("2d");
	
	field.width = fieldWidth;
	field.height = fieldHeight;

	var figure = new Figure();

	drawBg();
	figure.draw();
}



function drawBg() {
	ctxField.drawImage(board, 0, 0, 800, 800,
		0, 0, fieldWidth, fieldHeight);
}