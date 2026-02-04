// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {

    loadAll(); // default load
    $("#searchBox").on("keyup", function () {
        searchPlans($(this).val());
    });
});

// 🔹 Load all data
function loadAll() {
    searchPlans("");
}

// 🔹 AJAX search
function searchPlans(term) {
    $.ajax({
        url: '/ServicePlans/Search',
        type: 'GET',
        data: { term: term },
        success: function (response) {
            renderTable(response);
        }
    });
}

// 🔹 Render table
function renderTable(data) {

    var rows = "";

    if (data.length === 0) {
        rows = `<tr><td colspan="4" class="text-center text-muted">No data found</td></tr>`;
    } else {
        data.forEach(function (item) {

            let rowClass = item.totalHours > 20 ? "table-danger"
                : item.totalHours > 10 ? "table-warning"
                    : "table-success";

            rows += `
                <tr class="${rowClass}">
                    <td>${item.id}</td>
                    <td>${item.dateOfPurchase}</td>
                    <td>${item.timesheetCount}</td>
                    <td>${item.totalHours.toFixed(2)} hrs</td>
                </tr>
            `;
        });
    }

    $("#tableBody").html(rows);
}

