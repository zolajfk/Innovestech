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


    (function(){
  // Only on Single view
  if(!/\/grade\/report\/singleview\/index\.php$/.test(location.pathname)) return;

    // Hide the "Exclude" column (cells + header)
    document.addEventListener('DOMContentLoaded', function(){
        // Header with text "Exclude"
        document.querySelectorAll('table thead th').forEach(function (th) {
            if (th.textContent.trim().toLowerCase() === 'exclude' || th.textContent.trim().toLowerCase() === 'override' || th.textContent.trim().toLowerCase() === 'grade category' || th.textContent.trim().toLowerCase() === 'range') {
                const idx = Array.from(th.parentNode.children).indexOf(th);
                // hide header
                th.style.display = 'none';
                // hide corresponding cells
                document.querySelectorAll('table tbody tr').forEach(function (tr) {
                    const td = tr.children[idx];
                    if (td) td.style.display = 'none';
                });
            }
        });

        document.querySelectorAll('table thead td').forEach(function (th) {
            if (th.textContent.trim().toLowerCase() === '') {
                const idx = Array.from(th.parentNode.children).indexOf(th);
                // hide header
                th.style.display = 'none';
                // hide corresponding cells
                document.querySelectorAll('table tbody tr').forEach(function (tr) {
                    const td = tr.children[idx];
                    if (td) td.style.display = 'none';
                });
            }
        });

            document.querySelectorAll('input[name^="grade_"], input[name^="finalgrade_"]').forEach(function (inp) {
                if (inp.type === 'hidden' || inp.disabled) return;
                try { inp.type = 'number'; } catch (e) { }
                inp.setAttribute('inputmode', 'numeric');
                inp.setAttribute('min', '0');     // <-- adjust if needed
                inp.setAttribute('step', '1');    // <-- adjust if needed
                // Optional: uncomment and set your cap (e.g., 3)
                // inp.setAttribute('max','3');
                if (!inp.title) inp.title = 'Enter an integer (min 1)';
            });
            // If your Single view shows feedback as a short input anywhere, expand to textarea
            document.querySelectorAll('input[name^="feedback_"]').forEach(function (inp) {
                if (inp.type === 'hidden' || inp.disabled) return;
                var ta = document.createElement('textarea');
                ta.name = inp.name;
                ta.value = inp.value || '';
                ta.rows = 3; // tweak height if you like
                ta.className = inp.className;
                ['id', 'placeholder', 'aria-label'].forEach(function (a) {
                    if (inp.hasAttribute(a)) ta.setAttribute(a, inp.getAttribute(a));
                });
                inp.replaceWith(ta);
            });
            // Normalize existing TEXTAREAs too
            document.querySelectorAll('textarea[name^="feedback_"]').forEach(function (ta) {
                if (ta.rows < 3) ta.rows = 3;
            });

            // Optional: hide category “filter” row if you don’t want to show category UI at all
            // document.querySelectorAll('select[name="filtercategory"], .singleview-categoryfilter').forEach(el => el.style.display='none');
        });
})();

