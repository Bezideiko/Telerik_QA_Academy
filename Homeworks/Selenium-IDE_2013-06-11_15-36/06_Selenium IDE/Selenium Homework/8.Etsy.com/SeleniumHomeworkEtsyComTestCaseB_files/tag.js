function bt_eval(m,p){try{return window.eval.apply(window,[m])}catch(w){p&&p(w)}}function bt_parameter(m){return BrightTag.instance.parameter(m)}function bt_meta(m){return BrightTag.instance.meta(m)}function bt_cookie(m){return BrightTag.instance.cookie(m)}function bt_data(m,p){return BrightTag.instance.data(m,p)}window.bt_data_escaped=bt_data;function bt_log(m){window.console&&console.log&&console.log("BrightTag: "+m)}var bt_handle_exception=bt_log,_bt_url_prefix,_bt_referrer,_bt_site,_bt_mode;
function btServe(m){if(null==BrightTag.instance){var p=BrightTag,w=p.extend({referrer:_bt_referrer,site:_bt_site,mode:_bt_mode},p.defaultConfig());null!=_bt_url_prefix&&(w.host=_bt_url_prefix);p.instance=p.Main(p.extend(w,m||{}))}}
window.BrightTag=function(m){function p(a,c){return Object.prototype.toString.call(a)==="[object "+c+"]"}function w(a){return a.replace(/^\s\s*/,"").replace(/\s\s*$/,"")}function D(a){return"\n//at-sourceURL=/BrightTag/"+a.replace(/\s+/g,"_")+".js"}function s(a,c){for(var g in c)c.hasOwnProperty(g)&&(a[g]=c[g]);return a}function r(a,c){if(a)if(q.isArray(a)||a.length){var g,e;g=0;for(e=a.length;g<e;g++)c(a[g],g)}else if(q.isObject(a))for(g in a)a.hasOwnProperty(g)&&c(g,a[g])}function F(a){return!q.isString(a)?
a:a.replace(/%/g,"%25").replace(/#/g,"%23").replace(/&/g,"%26").replace(/'/g,"%27").replace(/;/g,"%3B").replace(/</g,"%3C").replace(/>/g,"%3E")}function N(a){function c(a){var d=Array.prototype.slice.call(arguments,1);r(m,function(b){var f=[h].concat(d);(b[a]||n).apply(null,f)})}function g(){z=!0;p=u.length;c("engine:off")}function e(){z&&c("engine:on");z=!1;v=0;(u[p++]||g)()}function k(){c("block:finish");e()}function l(d,b){return function(){var n=!1,h,f=a.createElement("script");f.onload=f.onreadystatechange=
function(){var a;if(!(a=n)){a:{switch(f.readyState){case void 0:case "loaded":case "complete":a=!0;break a}a=!1}a=!a}a||(n=!0,k())};f.onerror=function(){c("block:error",{type:"script",exception:"Problem loading "+d});n||k()};f.src=d;b&&(f.text=b);c("block:start",d);h=a.getElementsByTagName("script")[0];h.parentNode.insertBefore(f,h)}}function b(d){return function(){try{if(c("block:start",d),q.isString(d))if(a.defaultView){var b=D("tags/"+(x.tagId||"adhoc")+"-inline-b"+(p-1));a.defaultView.eval.call(window,
d+b)}else a.parentWindow?a.parentWindow.execScript(d):c("block:error",{type:"wait",exception:"Could not evaluate wait block ["+d+"]"});else d()}catch(n){c("block:error",{type:"wait",exception:n})}finally{k()}}}function f(a){u.push(a);z&&e();return h}function d(a){u.splice(p+v++,0,a);return h}var h=this,n=function(){},m=[],z=!1,x={},u=[],p=0,v=0;h.run=function(){c("engine:on");e()};h.options=function(a){s(x,a);return h};h.option=function(a){return x[a]};h.script=function(a){return f(l(a))};h.wait=
function(a){return f(b(a))};h.preemptScript=function(a,b){return d(l(a,b))};h.preemptWait=function(a){return d(b(a))};h.listen=function(a){m.push(a);(a["engine:listen"]||n).apply(null,[h]);return h}}function I(a){function c(a){l.push(a);f&&!d&&e()}function g(a){a.run()}function e(){var a=l[b];a&&(b++,a.listen(h).run())}var k,l=[],b=0,f=!1,d=!1,h={"engine:on":function(){d=!0},"engine:off":function(){d=!1;e()}};k=c;this.alwaysQueue=function(){k=c};this.neverQueue=function(){k=g};this.push=function(a){k(a);
return a};this.run=function(){f=!0;e()};this.applyListener=function(a){var d,h;d=b;for(h=l.length;d<h;d++)l[d].listen(a)};this.toString=function(){return"Group[name="+a+"; working="+d+"; running="+f+"]"}}function O(a){return{"engine:listen":function(c){c.listen(new P(a))}}}function B(a){function c(a){var f,d;a=a.split(/; ?/);k={};for(var h=0,n=a.length;h<n;h++){d=a[h];f=d.indexOf("=");var e=k,c=d.slice(0,f);f=d.slice(f+1);f=unescape(f);e[c]=f}}function g(b,f,d){if(b){d=d||{};b=[b+"="+F(f||"")];if((f=
d.expires)||0===f)q.isNumber(f)&&(f=(new Date(f)).toGMTString()),b.push("expires="+f);(f=d.path)&&b.push("path="+f);(f=d.domain)&&b.push("domain="+f);!0===d.secure&&b.push("Secure");!0===d.httponly&&b.push("HttpOnly");d=b.join(";");if(d.length<l)a.cookie=d;else throw{name:"CookieTooLongError",message:"Cookie reached 4096 byte limit"};c(a.cookie)}}function e(a,f){g(a,"",s(f||{},{expires:1}))}var k={},l=4096;c(a.cookie||"");return{get:function(a){return k[a]},set:g,remove:e,findEach:function(a,f){for(var d in k)k.hasOwnProperty(d)&&
d.match(a)&&f(d,k[d])},clear:function(a){var f=s({},k),d;for(d in f)e(d,a)}}}function Q(a){a=B(a);var c=a.set,g=a.remove;a.set=function(a,k,g){g=s(g||{},{path:"/"});0===g.expires&&(g.expires=+new Date("1/1/2038"));c(a,k,g)};a.remove=function(a,c){g(a,s(c||{},{path:"/"}))};a.purge=function(){};return a}function R(a,c){function g(a){a=a.expires;return 0!==a&&a<=+new Date}function e(d,h){a.setItem(d,h)}function k(a,h,f){h={value:h,expires:f};g(h)||c.setItem(a,JSON.stringify(h))}function l(a){a=c.getItem(a);
try{return a?JSON.parse(a):void 0}catch(h){}}function b(a){a=l(a);var h;return a&&(a.hasOwnProperty("value")&&a.hasOwnProperty("expires"))&&!g(a)?(h=a.value,delete a.value,[h,a]):[]}function f(a,h,f,b){for(var c,e=0,g=a.length;e<g;e++)c=a.key(e),!f[c]&&(f[c]=c.match(h))&&b(c)}return{set:function(a,h,f){a&&null!=h&&(f=f||{},(null!=f.expires?k:e)(a,h,f.expires))},get:function(d){return a.getItem(d)||b(d)[0]},findEach:function(d,h){var n={};f(a,d,n,function(d){var f=a.getItem(d);null!=f&&h(d,f)});f(c,
d,n,function(a){var d=b(a),f=d[0],d=d[1];null!=f&&h(a,f,d)})},remove:function(d){a.removeItem(d);c.removeItem(d)},purge:function(){for(var a,f,b=c.length;b--;)a=c.key(b),(f=l(a))&&(f.hasOwnProperty("value")&&f.hasOwnProperty("expires"))&&g(f)&&c.removeItem(a)}}}function S(a,c){var g={};g.set=a.set;g.findEach=function(e,g){var l={};a.findEach(e,function(a,f,d){l[a]=!0;g(a,f,d)});c.findEach(e,function(b,f,d){l[b]||(a.set(b,f,d),g(b,f,d))})};g.get=function(e){var g=a.get(e);void 0===g&&(g=c.get(e),void 0!==
g&&a.set(e,g));return g};g.remove=function(e){a.remove(e);c.remove(e)};g.purge=function(){a.purge();c.purge()};return g}function C(a){function c(a){if(!q.isString(a))return a;var d={};r(a.split("&"),function(a){if(""!==a){var f=a.split("=");a=decodeURIComponent(f[0]);f=f[1]&&decodeURIComponent(f[1].replace(/\+/g," "));(null==d[a]?d[a]=[]:d[a]).push(f)}});return d}function g(a,d){var b=[];r(a,function(a){if(q.isObject(a))return!1;a=null==a||""===a?d:a;(q.isString(a)||q.isNumber(a)||q.isBoolean(a))&&
b.push(a)});return b}function e(a){return!q.isArray(a)?[a]:a}function k(a,d){var b=encodeURIComponent(a),c=encodeURIComponent(d);return b+"="+c}var l=this,b={};s(b,c(a));l.param=function(a){a=b[a]||[""];return 1<a.length?a:a[0]};l.params=function(){return b};l.appendParam=function(a,d){if(a){var h=g(e(d));0<h.length&&(b[a]=(null==b[a]?b[a]=[]:b[a]).concat(h))}return this};l.replaceParam=function(a,d){if(a){var h=g(e(d));0<h.length&&(b[a]=(b[a]=[]).concat(h))}return this};l.appendParams=function(a){r(a,
l.appendParam);return this};l.alwaysAppendParam=function(a,d){if(a){var h=g(e(d),"");0<h.length&&(b[a]=(null==b[a]?b[a]=[]:b[a]).concat(h))}return this};l.alwaysReplaceParam=function(a,d){if(a){var h=g(e(d),"");0<h.length&&(b[a]=(b[a]=[]).concat(h))}return this};l.alwaysAppendParams=function(a){r(a,l.alwaysAppendParam);return this};l.appendPartialQueryString=function(a){a&&l.alwaysAppendParams(c(a));return this};l.deleteParam=function(a){delete b[a]};l.toString=function(){var a=[];r(b,function(d,
b){r(b,function(b){a.push(k(d,b))})});return a.join("&")}}function A(a){var c=this,g,e,k,l=a.indexOf("#");-1<l&&(k=a.substring(l+1),a=a.substring(0,l));l=a.indexOf("?");-1<l&&(e=a.substring(l+1),a=a.substring(0,l));g=a;a=new C(e);s(c,a);c.queryString=a.toString;c.toString=function(){var a=c.queryString();return g+(0<a.length?"?"+a:"")};c.asString=c.toString;c.fragment=function(){return k}}function J(a,c,g){function e(){var d=g.createEvent("Event");d.initEvent(c,!0,!1);try{d.currentTarget=d.target=
a}catch(b){bt_log("warning: can not set target for ["+c+"] event: "+b)}return d}function k(){var a=g.createEventObject("Event");a.type=c;a.cancelable=!0;a.bubbleable=!1;return a}function l(d){setTimeout(function(){try{d.call(a,b?e():k())}catch(f){bt_log("error: overriding ["+c+"] event: "+f)}},0)}var b=!!a.addEventListener,f=b?"addEventListener":"attachEvent",d=a[f];a[f]=function(e,f,g){if("function"==typeof f)if(e==c||e=="on"+c)l(f);else try{b?d.call(a,e,f,g):d(e,f)}catch(k){bt_log("error: proxying ["+
e+"] event: "+k)}}}function T(a,c){function g(b){d.push(e(b));a.set(h,k.toJSON())}function e(a){var d=q.isObject(a)?s({},a):{};d.type=d.type||"unknown";d.message=d.message||a.toString();d.timestamp=n;return d}if(!a)throw"ErrorManager requires a store";Math.random();var k={},l,b,f=!0,d=[],h="__bterr",n=+new Date,m=k.configure=function(a){a.hasOwnProperty("enabled")&&(f=a.enabled);a.hasOwnProperty("timestamp")&&(n=a.timestamp);a.hasOwnProperty("site")&&(l=a.site);a.hasOwnProperty("referrer")&&(b=a.referrer)};
c&&m(c);k.reset=function(b){b&&m(b);d=[];a.remove(h)};k.hasErrors=function(){return 0<d.length};k.toArray=function(){return d};k.toJSON=function(){try{return JSON.stringify({site:l,referrer:b,errors:d})}catch(a){bt_log("problem serializing errors: "+a.message)}return null};k.push=function(a){bt_log("error: "+JSON.stringify(a));if(f&&a&&!(-1>a.tagId||-1>a.pageId))try{g(a)}catch(d){if("CookieTooLongError"!=d.name)throw d;k.tooManyErrors()}};k.tooManyErrors=function(){k.reset();g({type:"runtime",message:"Too many errors"})};
k["block:error"]=function(a,d){if(d){var b=d.type,c=d.exception||d,e=a.option("tagId")||-1;k.push({type:b,message:c.toString(),tagId:e})}};k.processStoredErrors=function(){var c=a.get(h);if(c)try{var e=JSON.parse(c)||{};l=e.site;b=e.referrer;q.isArray(e.errors)&&(d=d.concat(e.errors))}catch(f){bt_log("problem reading stored errors: "+f.message)}};return k}function U(a,c){return new function(a,c){function k(a){h.wait(a)}function l(a){function b(){d=m.jQuery;k(a)}f="var $ = BrightTag.$; ";m.jQuery?
b():h.script(m.instance.baseUri()+"BrightTag.jquery-1.5.1.js").wait(b)}var b={},f="",d,h=m.Blab.group(c);b.getJQuery=function(){return d};b.ensureJQuery=function(f){b.ensureJQuery=k;d=a.jQuery;(d?k:l)(f);m.Blab.run(c)};b.functionWithAccess=function(a,d){return new Function(a,f+d)};return b}(a,c)}function K(a){function c(a,b){b&&b.findEach(a,function(a,d){e.appendParam(a,d)})}function g(a,b){return function(c){bt_log("invalid "+a+" expression: "+b+", exception = "+c)}}var e=this,k=a.window,l=a.parentReferrer,
b=a.referrer;A.call(this,0===a.host.length?"":(/^[a-z0-9+.-]+:\/\/.+/.test(a.host)?"":"//")+a.host+"/tag");e.appendParams({site:a.site,referrer:b,docReferrer:a.docReferrer,mode:a.mode,H:function(a){for(var b=5381,c=0,e=a.length;c<e;)b=(b<<5)+b+a.charCodeAt(c++);return b.toString(36)}(b||a.document.location.href)});b!==l&&e.appendParam("parentReferrer",l);c(/^btps\..+/,new B(a.document));c(/^btpdb\..+/,a.store);e.appendData=function(a){var b=bt_data(a),b=q.isArray(b)||q.isObject(b)?k.JSON.stringify(b):
b;return e.alwaysReplaceParam("_cb_"+("bt_data('"+a+"')"),b)};e.appendJs=function(a){var b=g("client binding expression",a);return e.alwaysReplaceParam("_cb_"+a,y(a,b))};e.cf=function(a){q.isArray(a)||(a=[a]);var b=e.param("cf");b&&(a=Array(b).concat(a));e.replaceParam("cf",a.join());return e};e.addCf=function(a,b){if(!y(b,g("conditional fire",b,"tags/"+a+"-cf.js")))return!1;var c=e.param("cf");e.replaceParam("cf",c?c+","+a:a);return!0};var f=e.toString();e.hasConditions=function(){return f!=e.toString()}}
function V(a,c){function g(a,b){r(b,function(b,d){a[a.type+"."+b]=d});c.push(a)}function e(a,b,d){var c=m.instance.serverURL();r(a,function(a){a.trigger(b,d,c)});c.hasConditions()&&m.Blab.script(c.asString())}function k(a,b,c){function k(b,e){r(l,function(f){var h,k=f.name;try{h=m[f.dbe];if(!h){var l=m,q=f.dbe,p,u=f.dbe,x=D("event-dbes/"+k+"-page-"+(t||"adhoc")+"-event-"+a);p=d.functionWithAccess(["eventObject","eventData"],"return "+u+";"+x);h=l[q]=p}c.data(k,h.call(b.target,b,e))}catch(r){g({type:"evdbe",
message:r.toString(),pageId:t||-1},{name:k,eventName:a})}})}var h={},l=[],m={},t=(b||{}).pageId;h.data=function(a,b){l.push({name:a,dbe:b});return h};h.applyDataBindings=k;h.handler=function(b){var d,c=f[a];c&&0<c.length&&(d=Array.prototype.slice.call(arguments,1),k(b,d),e(c,b,d))};return h}function l(a){function b(a){0<l.length&&(a.cf(l),r(m,function(b){a.appendData(b)}),r(p,function(b){a.appendJs(b)}))}function c(a,b){return function(d){bt_log("Invalid "+a+" expression: "+b+", exception = "+d)}}
var e={},f={},h,k,l=[],m=[],p=[];e.execute=function(b,c){s(f,c||{});if(q.isFunction(b))k=b;else if(q.isString(b))a:{try{var h=D("events/"+a+"-tag-"+(f.tagId||"adhoc"));k=d.functionWithAccess(["eventObject","eventData"],b+h);break a}catch(l){g({type:"evparse",message:l.toString(),tagId:f.tagId||-1},{eventName:a})}k=void 0}else bt_log("when.execute: unknown action: "+b);return e};e.evaluate=function(a){h=a;return e};e.fire=function(a){l.push(a);return e};e.appendData=function(a){m.push(a);return e};
e.appendJs=function(a){p.push(a);return e};e.trigger=function(d,e,l){var m=c("post-event conditional fire",h);if(!h||y(h,m)){try{k&&k.call(d.target,d,e)}catch(t){g({type:"evwait",message:t.toString(),tagId:f.tagId||-1},{eventName:a})}b(l)}};return e}var b={},f={},d=U(a,"BrightTag.jQuery"),h=/^direct\//i;b.executeActions=e;b.Binder=k;b.bind=function(a,b,c,e){var f=k(a,e,m.instance);d.ensureJQuery(function(){var a=d.getJQuery(),e=a(b);if(q.isString(b)&&!h.test(c)&&(e.on||e.live))if(e.on)a(document).on(c,
b,f.handler);else e.live(c,f.handler);else e.bind(c.split(h).pop(),f.handler)});return f};b.EventAction=l;b.when=function(a){var b=l(a),d=f[a];d||(d=f[a]=[]);d.push(b);return b};return b}function W(a,c){function g(b){null==l[b]&&(a.run(b),l[b]=!0)}function e(a){l[a]=!0}var k=!1,l={domready:!0};this.addTag=function(b,f){var d=f&&f.group;a.group(d||(!k?"domready":void 0)).options(f&&f.tagId?{tagId:f.tagId}:{}).wait(function(){c.write(b)});d&&(k?g:e)(d)};this.domReady=function(){k=!0;a.addGlobalListener(O(c));
r(l,a.run)}}function L(a,c){function g(a){r(q.isArray(a)?a:[a],function(a){q.isFunction(a)?a():u.write('<script type="text/javascript" src="'+a+'">\x3c/script>')})}function e(a){var b=v.group().options({tagId:-2});r(q.isArray(a)?a:[a],function(a){(q.isFunction(a)?b.wait:b.script)(a)})}function k(a){u.write(a)}function l(a,b){H.addTag(a,b)}function b(a){n.writeScript=a?g:e;n.appendContent=a?k:l}function f(){var b,d,c=a.mode,e="sync"===c;if(q.isArray(c)){b=0;for(d=c.length;!e&&b<d;b++)e="sync"===c[b]}return e}
function d(a){r(a,function(a){if(a.name){var b=s({},a);delete b.name;delete b.value;G.set(a.name,a.value,b)}})}function h(b){t.hasErrors()&&(b.appendParam("errors",t.toJSON()),2083<b.toString().length&&(b.deleteParam("errors"),t.tooManyErrors(),b.appendParam("errors",t.toJSON())));t.reset({site:a.site,referrer:a.referrer||u.location.href})}var n=this,p,z=a.data||{},x,u=a.document||{},w=a.window||{},v=a.blab||m.Blab,t=a.errorManager,G=a.store,H=a.asyncTagManager||new W(v,u);n.referrer=a.referrer;n.parentReferrer=
a.parentReferrer;n.docReferrer=a.docReferrer;n.site=a.site;n.host=a.host;n.loadOnly=!!a.loadOnly;t&&v.addGlobalListener(t);v.run("serializer");n.load=function(){var a=Array.prototype.slice.call(arguments,0);r(a,function(a){q.isFunction(a)?v.addToGroup("serializer",v.newEngine().wait(function(){a(n)})):q.isObject(a)&&a.src?n.library(a.src,a.options):q.isString(a)&&n.library(a)})};n.library=function(a,b){v.addToGroup("serializer",v.newEngine().options(b||{}).script(a))};b(f());n.domReady=function(){f()&&
b(!1);H.domReady()};n.parameter=function(a){null==p&&(p=new A(u.location.href));return p.param(a)};n.meta=function(a){x||(x={},r(u.getElementsByTagName("meta"),function(a){x[a.getAttribute("name")]=a.getAttribute("content")}));return x[a]||""};n.cookie=function(a){return(new B(u)).get(a)||""};n.data=function(a,b){if(void 0!==b)return z[a]=b;b=z[a];return null==b?"":b};n.dbe=function(a,b,d){n.data(a,y(b,function(b){t&&t.push({type:"dbe",message:b.toString(),"dbe.name":a,pageId:(d||{}).pageId||-1})},
"page-dbes/"+a+"-page-"+(d&&d.pageId||"adhoc")))};n.errors=function(a){t.configure(a)};n.store=G?d:function(){};n.serverURL=function(){return new K(a)};n.defaultBaseUri=function(){return("https:"==u.location.protocol?"https:":"http:")+"//s.btstatic.com/"};n.baseUri=function(){var a=/\btag(\.[^.]+|-n)?\.js(#.*)?$/;return c&&c.src&&c.src.replace(a,"")||n.defaultBaseUri()};n.primary=function(){function a(){var b=n.serverURL();t&&(t.processStoredErrors(),h(b));return b.toString()}var b=[];w.JSON?b.push(a()):
(b.push(n.baseUri()+"json2.js"),b.push(function(){n.writeScript(a())}));n.writeScript(b)};n.secondary=function(a){var b=n.serverURL(),d=b.toString();a(b);b.toString()!=d&&(t&&h(b),n.writeScript(b.toString()))}}function X(a){function c(){var c={},g=(new A(a.src)).fragment();g&&r((new C(g)).params(),function(a,b){c[a]=1<b.length?b:b[0]});return c}function g(){var c=w(a.innerHTML);return 0===c.length?{}:y("(\n"+c+"\n)",function(a){bt_log("configuration error: "+a)},"site-config")}return{isTagjs:function(){return/\/tag(\.[^.]+|-n)?\.js(\?.*)?(#.*)?$/.test(a.src)},
toJSON:function(){return s(c(),g())},script:a}}function Y(a){function c(){bt_log("v2: noop")}function g(a,c){void 0!==c&&(e[a]=c);var b=e[a];return null==b?"":b}a=s({},a);var e=s({},a.data);return{config:a,primary:c,secondary:c,dbe:function(a,c){g(a,y(c))},data:g,tag:c,bind:c,on:c}}function Z(a,c){var g,e,k=[];if(q.isArray(a))k=a.slice(0);else{g=0;for(e=a.length;g<e;g++)k.push(a[g])}return k}function M(){var a=Q(document),c;try{window.localStorage&&window.sessionStorage&&(c=R(sessionStorage,localStorage),
c.purge(),a=S(a,c))}catch(g){bt_log("Unable to access DOM storage: "+g)}return{id:Math.random(),loadOnly:!1,window:window,document:document,host:"s.thebrighttag.com",parentReferrer:top!=self&&self.window?self.window.location.href:null,docReferrer:document.referrer,data:{},store:a,errorManager:T(a)}}if(m)return bt_log("tried to load tag.js again"),m;m={};var q={isString:function(a){return p(a,"String")},isArray:function(a){return p(a,"Array")},isNumber:function(a){return p(a,"Number")},isBoolean:function(a){return p(a,
"Boolean")},isFunction:function(a){return p(a,"Function")},isObject:function(a){return null===a||void 0===a?!1:p(a,"Object")}},y=bt_eval,P=function(){var a,c=[],g=function(c){a.push(c)};return function(e){function k(a){a.src?b.preemptScript(a.src,a.innerHTML):a.innerHTML&&b.preemptWait(a.innerHTML)}function l(a){try{e.body.appendChild(a.cloneNode(!0))}catch(b){bt_log("error appending content to body: "+b)}}var b,f=e.createElement("div");this["block:start"]=function(){var b=e;c.push([a,b.write,b.writeln]);
a=[];b.write=b.writeln=g};this["block:finish"]=function(){try{if(0!==a.length){f.innerHTML="<br/>"+a.join("");var b,g,m=f.childNodes||[];b=1;for(g=m.length;b<g;b++)("SCRIPT"==m[b].tagName?k:l)(m[b])}}finally{b=e,g=c.pop(),a=g[0],b.write=g[1],b.writeln=g[2]}};this["engine:listen"]=function(a){b=a}}}(),E={};m.Escaper={cookie:F,javascript:function(a){return!q.isString(a)?a:a.replace(/\\/g,"\\\\").replace(/'/g,"\\x27").replace(/"/g,"\\x22").replace(/\n/g,"\\n").replace(/\r/g,"\\r")}};m.Random={integer:function(a){return Math.floor(Math.random()*
(a||1E8))}};m.pushIfDefined=function(a,c,g){a&&(a.constructor==Array&&null!=c)&&a.push(g||c)};m.Types=q;m.trim=w;m.each=r;m.extend=s;m.eval=y;m.HTTP={Cookie:B,QueryString:C,URL:A};m.Blab=new function(a){function c(a){return k[a]||(k[a]=new I(a))}function g(a){return e.addToGroup(a,e.newEngine())}var e=this,k={undefined:new I(void 0)},l=[];k.undefined.neverQueue();e.addGlobalListener=function(a){l.push(a);r(k,function(c,d){d.applyListener(a)})};e.addToGroup=function(a,e){r(l,function(a){e.listen(a)});
return c(a).push(e)};e.newEngine=function(){return new N(a)};e.group=function(a){return g(a)};e.listen=function(){return g().listen.apply(null,arguments)};e.script=function(){return g().script.apply(null,arguments)};e.wait=function(){return g().wait.apply(null,arguments)};e.run=function(a){c(a).run()};e.alwaysQueue=function(a){c(a).alwaysQueue()};e.neverQueue=function(a){c(a).neverQueue()};e.setOptions=function(){return g()}}(document);m.$LAB=m.Blab;m.Events=new function(a,c){function g(){}function e(a,
b,c){a[r](s+b,c,!1)}function k(a,b,c){a[u](s+b,c,!1)}function l(){var a=c.readyState;if("loading"==a)return!1;if("complete"==a)return!0;a:{try{v("left")}catch(b){a=!1;break a}a=!0}return a}function b(a,c,d){var e=this;setTimeout(function(){a()?c.call(e):b(a,c,d)},d)}function f(){f=g;m&&J(c,p,c)}function d(){f();J(a,q,c)}var h=this,m=!!a.addEventListener,p="DOMContentLoaded",q="load",r=m?"addEventListener":"attachEvent",u=m?"removeEventListener":"detachEvent",s=m?"":"on",v=c.documentElement.doScroll||
function(){throw"No doScroll";};h.listen=e;h.unlisten=k;h.onDOMReady=function(d){l()?d.call(this):c.addEventListener?(e(c,p,d),e(c,p,function(){k(a,q,d)}),e(a,q,d)):b(l,d,1)};h.enablePageReadyOverrides=function(){h.enablePageReadyOverrides=g;l()?d():(m&&e(c,p,f),e(a,q,d))}}(window,document);m.Events.enablePageReadyOverrides();m.ServerURL=K;m.Main=function(a){function c(b){(b=(new A(b.src)).fragment())&&r((new C(b)).params(),function(b,c){a[b]=c[0]})}function g(b){function c(a){bt_log("configuration error: "+
a)}b=w(b.innerHTML);0!==b.length&&s(a,y("(\n"+b+"\n)",c,"site-config"))}var e,k=function(){var b,c,d=/\/tag(\.[^.]+|-n)?\.js(#.*)?$/,e=a.document.getElementsByTagName("script");for(b=e.length-1;-1<b;b--)if(c=e[b],d.test(c.src))return c}();k&&(c(k),g(k));if(null!=a.site){m.Events.enablePageReadyOverrides();try{e=new L(a,k),m.Events.onDOMReady(e.domReady),e.loadOnly||e.primary()}catch(l){bt_log("execution error: "+l)}return e}};m.CookieSync={pushImage:function(a){(new Image).src=a;throw"CookieSync.pushImage no longer supported ["+
a+"]";},pushIframe:function(a){throw"CookieSync.pushIframe no longer supported ["+a+"]";}};m.defaultConfig=M;m.site=function(a,c){var g=E[a];g&&c&&c(g);return g};m.main=function(a,c){r(Z(a.document.getElementsByTagName("script")),function(a){a=X(a);if(a.isTagjs())try{var e=a.toJSON();if(e.site&&!m.instance&&"v2"!==e.mode){var k=a.script,l=M();m.EventBinding=V(l.window,l.errorManager);m.instance=new L(s(l,e),k);c&&c(m.instance,!0)}else{e.mode="v2";var b=e.site;site=b&&!E[b]?E[b]=Y(e):void 0;site&&
c&&c(site,!1)}}catch(f){bt_log("error configuring site ["+a.script.src+"]: "+f)}})};return m}(window.BrightTag);(function(){function m(m,w){w?(BrightTag.Events.onDOMReady(m.domReady),m.loadOnly||m.primary()):m.primary()}BrightTag.main(window,m);null==BrightTag.instance&&setTimeout(function(){null==BrightTag.instance&&BrightTag.main(window,m)},0)})();
