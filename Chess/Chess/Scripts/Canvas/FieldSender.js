function sendField(parametr) {
	var field; //как-то получить поле или сделанный игроком ход, может быть получить в качестве параметра.
	var answer = JSON.stringify(parametr);//(field)
	console.log(answer);
	$.ajax(
		{
			type: "POST",
			url: $("#SendField").data("url"),
			data: {
				field: answer
			}
		}).success(function(newFieldState) {
			alert(newFieldState);
			console.log(newFieldState);
		})
		.fail(function(req) {
			console.log(req.responseText);
		})
		.always(function(ans) {
		});
}
