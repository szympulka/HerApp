function addNot() {
	if (!$("#alerts div").length) {
		$('#alerts').append('<div>			'
			+ '<img src="https://herapp.azurewebsites.net/images/126.png"/>'
			+ '<span>Thinking...</span></div>');
	}
}
$("input:submit").on("click", addNot);
$(".loader").on("click", addNot);
$("button").on("click", addNot);