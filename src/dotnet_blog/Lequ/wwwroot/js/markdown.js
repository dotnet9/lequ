// apply HighlightJS
var pres = document.querySelectorAll("pre>code");
for (var i = 0; i < pres.length; i++) {
    hljs.highlightBlock(pres[i]);
}

// https://github.com/RickStrahl/highlightjs-badge
window.highlightJsBadge();