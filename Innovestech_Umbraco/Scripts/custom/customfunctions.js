function GetURLParameter(sParam, sDefault) {
    var sPageURL = window.location.search.substring(1).toUpperCase();
    var sURLVariables = sPageURL.split('&');
    for (var i = 0; i < sURLVariables.length; i++) {
        var sParameterName = sURLVariables[i].split('=');
        if (sParameterName[0] === sParam.toUpperCase()) {
            return sParameterName[1];
        }
    }
    return sDefault;
}

function setUrlParameter(url, key, value) {
    key = encodeURIComponent(key);
    value = encodeURIComponent(value);

    var baseUrl = url.split('?')[0],
        newParam = key + '=' + value,
        params = '?' + newParam;

    if (url.split('?')[1] === undefined) { // if there are no query strings, make urlQueryString empty
        urlQueryString = '';
    } else {
        urlQueryString = '?' + url.split('?')[1];
    }

    // If the "search" string exists, then build params from it
    if (urlQueryString) {
        var updateRegex = new RegExp('([\?&])' + key + '[^&]*');
        var removeRegex = new RegExp('([\?&])' + key + '=[^&;]+[&;]?');

        if (typeof value === 'undefined' || value === null || value === '') { // Remove param if value is empty
            params = urlQueryString.replace(removeRegex, "$1");
            params = params.replace(/[&;]$/, "");

        } else if (urlQueryString.match(updateRegex) !== null) { // If param exists already, update it
            params = urlQueryString.replace(updateRegex, "$1" + newParam);

        } else if (urlQueryString === '') { // If there are no query strings
            params = '?' + newParam;
        } else { // Otherwise, add it to end of query string
            params = urlQueryString + '&' + newParam;
        }
    }

    // no parameter was set so we don't need the question mark
    params = params === '?' ? '' : params;

    history.replaceState(null, null, baseUrl + params);
    return baseUrl + params;
}

function logError(functionName, jqX, textStatus, errorThrown) {
    jQuery.ajax({
        url: '/umbraco/Surface/ErrorsSurface/LogError',
        type: 'POST',
        data: JSON.stringify({
            functionName: functionName,
            jqX: jqX,
            textStatus: "@Request.UserHostAddress",
            errorThrown: errorThrown
        }),
        contentType: 'application/json'
    });
    };
