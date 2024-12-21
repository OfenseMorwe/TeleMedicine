$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: '/Account/AdmissionDashboard',  // Make sure this matches your routing
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            const ctx = document.getElementById('barChart_div').getContext('2d'); // Use correct ID
            const NumofUsers = data[0];
            const adminRoles = data[1];

            // Create the pie chart
            new Chart(ctx, {
                type: 'doughnut',
                data: {
                    labels: NumofUsers ,
                    datasets: [{
                        label: "Admissions",
                        backgroundColor: [
                            "#FF6384",
                            "#36A2EB",
                            "#FFCE56",
                            "#FF6384",
                            "#36A2EB",
                            "#FFCE56",
                            "#FF6384"
                        ],
                        data: adminRoles,
                    }]
                },
                options: {
                    responsive: true,
                    plugins: {
                        legend: {
                            display: true,
                            position: 'bottom',
                        }
                    }
                }
            });
        },
        error: function (error) {
            console.error("Error fetching data for pie chart: ", error);
        }
    });
});
