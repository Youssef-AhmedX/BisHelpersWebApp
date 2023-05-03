

function generatePDF()
{
    const element = document.getElementById("Report");

	var opt =
	{
		margin: 0.5,
		filename: 'GPA Analysis Report.pdf',
		image: { type: 'jpeg', quality: 0.98 },
		html2canvas: { scale: 2 },
		jsPDF: { unit: 'in', format: 'letter', orientation: 'portrait' }
	};

	// New Promise-based usage:
	html2pdf()
		.set(opt)
		.from(element)
		.save();

}

