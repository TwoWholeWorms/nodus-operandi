/**
 * NodusOperandi JS
 */

$(document).ready(function () {

    var _widgets = $('.dash-widget.chart-widget');
    for (var i = 0; i < _widgets.length; i++) {
        var _chartWidget = $(_widgets.get(i));

        var _chartContext = _chartWidget.find('.chart > canvas')[0].getContext("2d");
        var _chart = new Chart(_chartContext);

        var _chartData = {
            labels:[],
            datasets:[
                {
                    label:'Speed (MB/s)',
                    data:$(_chartWidget.find('.chart')).data('series')
                }
            ]
        };
        var _chartInstance = _chart.Bar(_chartData, {});

        _chartWidget.data('chart', _chartInstance);
    }

});
