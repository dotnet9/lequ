/** layuiAdmin.pro-v1.2.1 LPPL License By http://www.layui.com/admin/ */
 ;!function(){var t=window,e=document,n=t.MooTools.version.substring(0,3),r="1.2"===n||"1.1"===n,a=r||"1.3"===n,i=t.$extend||function(){return Object.append.apply(Object,arguments)};t.HighchartsAdapter={init:function(t){var e=Fx.prototype,n=e.start,r=Fx.Morph.prototype,a=r.compute;e.start=function(e,r){var a=this.element;return e.d&&(this.paths=t.init(a,a.d,this.toD)),n.apply(this,arguments),this},r.compute=function(e,n,r){var i=this.paths;return i?void this.element.attr("d",t.step(i[0],i[1],r,this.toD)):a.apply(this,arguments)}},adapterRun:function(t,e){if("width"===e||"height"===e)return parseInt($(t).getStyle(e),10)},getScript:function(t,n){var r=e.getElementsByTagName("head")[0],a=e.createElement("script");a.type="text/javascript",a.src=t,a.onload=n,r.appendChild(a)},animate:function(e,n,r){var a=e.attr,o=r&&r.complete;a&&!e.setStyle&&(e.getStyle=e.attr,e.setStyle=function(){var t=arguments;this.attr.call(this,t[0],t[1][0])},e.$family=function(){return!0}),t.HighchartsAdapter.stop(e),r=new Fx.Morph(a?e:$(e),i({transition:Fx.Transitions.Quad.easeInOut},r)),a&&(r.element=e),n.d&&(r.toD=n.d),o&&r.addEvent("complete",o),r.start(n),e.fx=r},each:function(t,e){return r?$each(t,e):Array.each(t,e)},map:function(t,e){return t.map(e)},grep:function(t,e){return t.filter(e)},inArray:function(t,e,n){return e?e.indexOf(t,n):-1},offset:function(t){return t=t.getPosition(),{left:t.x,top:t.y}},extendWithEvents:function(t){t.addEvent||(t.nodeName?$(t):i(t,new Events))},addEvent:function(e,n,r){"string"==typeof n&&("unload"===n&&(n="beforeunload"),t.HighchartsAdapter.extendWithEvents(e),e.addEvent(n,r))},removeEvent:function(t,e,n){"string"!=typeof t&&t.addEvent&&(e?("unload"===e&&(e="beforeunload"),n?t.removeEvent(e,n):t.removeEvents&&t.removeEvents(e)):t.removeEvents())},fireEvent:function(t,e,n,r){e={type:e,target:t},e=a?new Event(e):new DOMEvent(e),e=i(e,n),!e.target&&e.event&&(e.target=e.event.target),e.preventDefault=function(){r=null},t.fireEvent&&t.fireEvent(e.type,e),r&&r(e)},washMouseEvent:function(t){return t.page&&(t.pageX=t.page.x,t.pageY=t.page.y),t},stop:function(t){t.fx&&t.fx.cancel()}}}();