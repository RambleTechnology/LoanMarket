!function(a){"function"==typeof define&&define.amd?define(["jquery"],a):"object"==typeof exports?a(require("jquery")):a(jQuery)}(function(a){var b=0,c=Array.prototype.slice;a.cleanData=function(b){return function(c){var d,e,f;for(f=0;null!=(e=c[f]);f++)try{d=a._data(e,"events"),d&&d.remove&&a(e).triggerHandler("remove")}catch(g){}b(c)}}(a.cleanData),a.widget=function(b,c,d){var e,f,g,h,i={},j=b.split(".")[0];return b=b.split(".")[1],e=j+"-"+b,d||(d=c,c=a.Widget),a.expr[":"][e.toLowerCase()]=function(b){return!!a.data(b,e)},a[j]=a[j]||{},f=a[j][b],g=a[j][b]=function(a,b){return this._createWidget?(arguments.length&&this._createWidget(a,b),void 0):new g(a,b)},a.extend(g,f,{version:d.version,_proto:a.extend({},d),_childConstructors:[]}),h=new c,h.options=a.widget.extend({},h.options),a.each(d,function(b,d){return a.isFunction(d)?(i[b]=function(){var a=function(){return c.prototype[b].apply(this,arguments)},e=function(a){return c.prototype[b].apply(this,a)};return function(){var f,b=this._super,c=this._superApply;return this._super=a,this._superApply=e,f=d.apply(this,arguments),this._super=b,this._superApply=c,f}}(),void 0):(i[b]=d,void 0)}),g.prototype=a.widget.extend(h,{widgetEventPrefix:f?h.widgetEventPrefix||b:b},i,{constructor:g,namespace:j,widgetName:b,widgetFullName:e}),f?(a.each(f._childConstructors,function(b,c){var d=c.prototype;a.widget(d.namespace+"."+d.widgetName,g,c._proto)}),delete f._childConstructors):c._childConstructors.push(g),a.widget.bridge(b,g),g},a.widget.extend=function(b){for(var g,h,d=c.call(arguments,1),e=0,f=d.length;f>e;e++)for(g in d[e])h=d[e][g],d[e].hasOwnProperty(g)&&void 0!==h&&(b[g]=a.isPlainObject(h)?a.isPlainObject(b[g])?a.widget.extend({},b[g],h):a.widget.extend({},h):h);return b},a.widget.bridge=function(b,d){var e=d.prototype.widgetFullName||b;a.fn[b]=function(f){var g="string"==typeof f,h=c.call(arguments,1),i=this;return g?this.each(function(){var c,d=a.data(this,e);return"instance"===f?(i=d,!1):d?a.isFunction(d[f])&&"_"!==f.charAt(0)?(c=d[f].apply(d,h),c!==d&&void 0!==c?(i=c&&c.jquery?i.pushStack(c.get()):c,!1):void 0):a.error("no such method '"+f+"' for "+b+" widget instance"):a.error("cannot call methods on "+b+" prior to initialization; "+"attempted to call method '"+f+"'")}):(h.length&&(f=a.widget.extend.apply(null,[f].concat(h))),this.each(function(){var b=a.data(this,e);b?(b.option(f||{}),b._init&&b._init()):a.data(this,e,new d(f,this))})),i}},a.Widget=function(){},a.Widget._childConstructors=[],a.Widget.prototype={widgetName:"widget",widgetEventPrefix:"",defaultElement:"<div>",options:{disabled:!1,create:null},_createWidget:function(c,d){d=a(d||this.defaultElement||this)[0],this.element=a(d),this.uuid=b++,this.eventNamespace="."+this.widgetName+this.uuid,this.bindings=a(),this.hoverable=a(),this.focusable=a(),d!==this&&(a.data(d,this.widgetFullName,this),this._on(!0,this.element,{remove:function(a){a.target===d&&this.destroy()}}),this.document=a(d.style?d.ownerDocument:d.document||d),this.window=a(this.document[0].defaultView||this.document[0].parentWindow)),this.options=a.widget.extend({},this.options,this._getCreateOptions(),c),this._create(),this._trigger("create",null,this._getCreateEventData()),this._init()},_getCreateOptions:a.noop,_getCreateEventData:a.noop,_create:a.noop,_init:a.noop,destroy:function(){this._destroy(),this.element.unbind(this.eventNamespace).removeData(this.widgetFullName).removeData(a.camelCase(this.widgetFullName)),this.widget().unbind(this.eventNamespace).removeAttr("aria-disabled").removeClass(this.widgetFullName+"-disabled "+"ui-state-disabled"),this.bindings.unbind(this.eventNamespace),this.hoverable.removeClass("ui-state-hover"),this.focusable.removeClass("ui-state-focus")},_destroy:a.noop,widget:function(){return this.element},option:function(b,c){var e,f,g,d=b;if(0===arguments.length)return a.widget.extend({},this.options);if("string"==typeof b)if(d={},e=b.split("."),b=e.shift(),e.length){for(f=d[b]=a.widget.extend({},this.options[b]),g=0;g<e.length-1;g++)f[e[g]]=f[e[g]]||{},f=f[e[g]];if(b=e.pop(),1===arguments.length)return void 0===f[b]?null:f[b];f[b]=c}else{if(1===arguments.length)return void 0===this.options[b]?null:this.options[b];d[b]=c}return this._setOptions(d),this},_setOptions:function(a){var b;for(b in a)this._setOption(b,a[b]);return this},_setOption:function(a,b){return this.options[a]=b,"disabled"===a&&(this.widget().toggleClass(this.widgetFullName+"-disabled",!!b),b&&(this.hoverable.removeClass("ui-state-hover"),this.focusable.removeClass("ui-state-focus"))),this},enable:function(){return this._setOptions({disabled:!1})},disable:function(){return this._setOptions({disabled:!0})},_on:function(b,c,d){var e,f=this;"boolean"!=typeof b&&(d=c,c=b,b=!1),d?(c=e=a(c),this.bindings=this.bindings.add(c)):(d=c,c=this.element,e=this.widget()),a.each(d,function(d,g){function h(){return b||f.options.disabled!==!0&&!a(this).hasClass("ui-state-disabled")?("string"==typeof g?f[g]:g).apply(f,arguments):void 0}"string"!=typeof g&&(h.guid=g.guid=g.guid||h.guid||a.guid++);var i=d.match(/^([\w:-]*)\s*(.*)$/),j=i[1]+f.eventNamespace,k=i[2];k?e.delegate(k,j,h):c.bind(j,h)})},_off:function(b,c){c=(c||"").split(" ").join(this.eventNamespace+" ")+this.eventNamespace,b.unbind(c).undelegate(c),this.bindings=a(this.bindings.not(b).get()),this.focusable=a(this.focusable.not(b).get()),this.hoverable=a(this.hoverable.not(b).get())},_delay:function(a,b){function c(){return("string"==typeof a?d[a]:a).apply(d,arguments)}var d=this;return setTimeout(c,b||0)},_hoverable:function(b){this.hoverable=this.hoverable.add(b),this._on(b,{mouseenter:function(b){a(b.currentTarget).addClass("ui-state-hover")},mouseleave:function(b){a(b.currentTarget).removeClass("ui-state-hover")}})},_focusable:function(b){this.focusable=this.focusable.add(b),this._on(b,{focusin:function(b){a(b.currentTarget).addClass("ui-state-focus")},focusout:function(b){a(b.currentTarget).removeClass("ui-state-focus")}})},_trigger:function(b,c,d){var e,f,g=this.options[b];if(d=d||{},c=a.Event(c),c.type=(b===this.widgetEventPrefix?b:this.widgetEventPrefix+b).toLowerCase(),c.target=this.element[0],f=c.originalEvent)for(e in f)e in c||(c[e]=f[e]);return this.element.trigger(c,d),!(a.isFunction(g)&&g.apply(this.element[0],[c].concat(d))===!1||c.isDefaultPrevented())}},a.each({show:"fadeIn",hide:"fadeOut"},function(b,c){a.Widget.prototype["_"+b]=function(d,e,f){"string"==typeof e&&(e={effect:e});var g,h=e?e===!0||"number"==typeof e?c:e.effect||c:b;e=e||{},"number"==typeof e&&(e={duration:e}),g=!a.isEmptyObject(e),e.complete=f,e.delay&&d.delay(e.delay),g&&a.effects&&a.effects.effect[h]?d[b](e):h!==b&&d[h]?d[h](e.duration,e.easing,f):d.queue(function(c){a(this)[b](),f&&f.call(d[0]),c()})}}),a.widget});
/*
 * jQuery File Upload Plugin
 * https://github.com/blueimp/jQuery-File-Upload
 *
 * Copyright 2010, Sebastian Tschan
 * https://blueimp.net
 *
 * Licensed under the MIT license:
 * http://www.opensource.org/licenses/MIT
 */

/* jshint nomen:false */
/* global define, require, window, document, location, Blob, FormData */
(function(factory){if(typeof define==="function"&&define.amd){define(["jquery","jquery.ui.widget"],factory)}else{if(typeof exports==="object"){factory(require("jquery"),require("./vendor/jquery.ui.widget"))}else{factory(window.jQuery)}}}(function($){$.support.fileInput=!(new RegExp("(Android (1\\.[0156]|2\\.[01]))"+"|(Windows Phone (OS 7|8\\.0))|(XBLWP)|(ZuneWP)|(WPDesktop)"+"|(w(eb)?OSBrowser)|(webOS)"+"|(Kindle/(1\\.0|2\\.[05]|3\\.0))").test(window.navigator.userAgent)||$('<input type="file">').prop("disabled"));$.support.xhrFileUpload=!!(window.ProgressEvent&&window.FileReader);$.support.xhrFormDataFileUpload=!!window.FormData;$.support.blobSlice=window.Blob&&(Blob.prototype.slice||Blob.prototype.webkitSlice||Blob.prototype.mozSlice);function getDragHandler(type){var isDragOver=type==="dragover";return function(e){e.dataTransfer=e.originalEvent&&e.originalEvent.dataTransfer;var dataTransfer=e.dataTransfer;if(dataTransfer&&$.inArray("Files",dataTransfer.types)!==-1&&this._trigger(type,$.Event(type,{delegatedEvent:e}))!==false){e.preventDefault();if(isDragOver){dataTransfer.dropEffect="copy"}}}}$.widget("blueimp.fileupload",{options:{dropZone:$(document),pasteZone:undefined,fileInput:undefined,replaceFileInput:true,paramName:undefined,singleFileUploads:true,limitMultiFileUploads:undefined,limitMultiFileUploadSize:undefined,limitMultiFileUploadSizeOverhead:512,sequentialUploads:false,limitConcurrentUploads:undefined,forceIframeTransport:false,redirect:undefined,redirectParamName:undefined,postMessage:undefined,multipart:true,maxChunkSize:undefined,uploadedBytes:undefined,recalculateProgress:true,progressInterval:100,bitrateInterval:500,autoUpload:true,messages:{uploadedBytes:"Uploaded bytes exceed file size"},i18n:function(message,context){message=this.messages[message]||message.toString();if(context){$.each(context,function(key,value){message=message.replace("{"+key+"}",value)})}return message},formData:function(form){return form.serializeArray()},add:function(e,data){if(e.isDefaultPrevented()){return false}if(data.autoUpload||(data.autoUpload!==false&&$(this).fileupload("option","autoUpload"))){data.process().done(function(){data.submit()})}},processData:false,contentType:false,cache:false,timeout:0},_specialOptions:["fileInput","dropZone","pasteZone","multipart","forceIframeTransport"],_blobSlice:$.support.blobSlice&&function(){var slice=this.slice||this.webkitSlice||this.mozSlice;return slice.apply(this,arguments)},_BitrateTimer:function(){this.timestamp=((Date.now)?Date.now():(new Date()).getTime());this.loaded=0;this.bitrate=0;this.getBitrate=function(now,loaded,interval){var timeDiff=now-this.timestamp;if(!this.bitrate||!interval||timeDiff>interval){this.bitrate=(loaded-this.loaded)*(1000/timeDiff)*8;this.loaded=loaded;this.timestamp=now}return this.bitrate}},_isXHRUpload:function(options){return !options.forceIframeTransport&&((!options.multipart&&$.support.xhrFileUpload)||$.support.xhrFormDataFileUpload)},_getFormData:function(options){var formData;if($.type(options.formData)==="function"){return options.formData(options.form)}if($.isArray(options.formData)){return options.formData}if($.type(options.formData)==="object"){formData=[];$.each(options.formData,function(name,value){formData.push({name:name,value:value})});return formData}return[]},_getTotal:function(files){var total=0;$.each(files,function(index,file){total+=file.size||1});return total},_initProgressObject:function(obj){var progress={loaded:0,total:0,bitrate:0};if(obj._progress){$.extend(obj._progress,progress)}else{obj._progress=progress}},_initResponseObject:function(obj){var prop;if(obj._response){for(prop in obj._response){if(obj._response.hasOwnProperty(prop)){delete obj._response[prop]}}}else{obj._response={}}},_onProgress:function(e,data){if(e.lengthComputable){var now=((Date.now)?Date.now():(new Date()).getTime()),loaded;if(data._time&&data.progressInterval&&(now-data._time<data.progressInterval)&&e.loaded!==e.total){return}data._time=now;loaded=Math.floor(e.loaded/e.total*(data.chunkSize||data._progress.total))+(data.uploadedBytes||0);this._progress.loaded+=(loaded-data._progress.loaded);this._progress.bitrate=this._bitrateTimer.getBitrate(now,this._progress.loaded,data.bitrateInterval);data._progress.loaded=data.loaded=loaded;data._progress.bitrate=data.bitrate=data._bitrateTimer.getBitrate(now,loaded,data.bitrateInterval);this._trigger("progress",$.Event("progress",{delegatedEvent:e}),data);this._trigger("progressall",$.Event("progressall",{delegatedEvent:e}),this._progress)}},_initProgressListener:function(options){var that=this,xhr=options.xhr?options.xhr():$.ajaxSettings.xhr();if(xhr.upload){$(xhr.upload).bind("progress",function(e){var oe=e.originalEvent;e.lengthComputable=oe.lengthComputable;e.loaded=oe.loaded;e.total=oe.total;that._onProgress(e,options)});options.xhr=function(){return xhr}}},_isInstanceOf:function(type,obj){return Object.prototype.toString.call(obj)==="[object "+type+"]"},_initXHRData:function(options){var that=this,formData,file=options.files[0],multipart=options.multipart||!$.support.xhrFileUpload,paramName=$.type(options.paramName)==="array"?options.paramName[0]:options.paramName;
options.headers=$.extend({},options.headers);if(options.contentRange){options.headers["Content-Range"]=options.contentRange}if(!multipart||options.blob||!this._isInstanceOf("File",file)){options.headers["Content-Disposition"]='attachment; filename="'+encodeURI(file.name)+'"'}if(!multipart){options.contentType=file.type||"application/octet-stream";options.data=options.blob||file}else{if($.support.xhrFormDataFileUpload){if(options.postMessage){formData=this._getFormData(options);if(options.blob){formData.push({name:paramName,value:options.blob})}else{$.each(options.files,function(index,file){formData.push({name:($.type(options.paramName)==="array"&&options.paramName[index])||paramName,value:file})})}}else{if(that._isInstanceOf("FormData",options.formData)){formData=options.formData}else{formData=new FormData();$.each(this._getFormData(options),function(index,field){formData.append(field.name,field.value)})}if(options.blob){formData.append(paramName,options.blob,file.name)}else{$.each(options.files,function(index,file){if(that._isInstanceOf("File",file)||that._isInstanceOf("Blob",file)){formData.append(($.type(options.paramName)==="array"&&options.paramName[index])||paramName,file,file.uploadName||file.name)}})}}options.data=formData}}options.blob=null},_initIframeSettings:function(options){var targetHost=$("<a></a>").prop("href",options.url).prop("host");options.dataType="iframe "+(options.dataType||"");options.formData=this._getFormData(options);if(options.redirect&&targetHost&&targetHost!==location.host){options.formData.push({name:options.redirectParamName||"redirect",value:options.redirect})}},_initDataSettings:function(options){if(this._isXHRUpload(options)){if(!this._chunkedUpload(options,true)){if(!options.data){this._initXHRData(options)}this._initProgressListener(options)}if(options.postMessage){options.dataType="postmessage "+(options.dataType||"")}}else{this._initIframeSettings(options)}},_getParamName:function(options){var fileInput=$(options.fileInput),paramName=options.paramName;if(!paramName){paramName=[];fileInput.each(function(){var input=$(this),name=input.prop("name")||"files[]",i=(input.prop("files")||[1]).length;while(i){paramName.push(name);i-=1}});if(!paramName.length){paramName=[fileInput.prop("name")||"files[]"]}}else{if(!$.isArray(paramName)){paramName=[paramName]}}return paramName},_initFormSettings:function(options){if(!options.form||!options.form.length){options.form=$(options.fileInput.prop("form"));if(!options.form.length){options.form=$(this.options.fileInput.prop("form"))}}options.paramName=this._getParamName(options);if(!options.url){options.url=options.form.prop("action")||location.href}options.type=(options.type||($.type(options.form.prop("method"))==="string"&&options.form.prop("method"))||"").toUpperCase();if(options.type!=="POST"&&options.type!=="PUT"&&options.type!=="PATCH"){options.type="POST"}if(!options.formAcceptCharset){options.formAcceptCharset=options.form.attr("accept-charset")}},_getAJAXSettings:function(data){var options=$.extend({},this.options,data);this._initFormSettings(options);this._initDataSettings(options);return options},_getDeferredState:function(deferred){if(deferred.state){return deferred.state()}if(deferred.isResolved()){return"resolved"}if(deferred.isRejected()){return"rejected"}return"pending"},_enhancePromise:function(promise){promise.success=promise.done;promise.error=promise.fail;promise.complete=promise.always;return promise},_getXHRPromise:function(resolveOrReject,context,args){var dfd=$.Deferred(),promise=dfd.promise();context=context||this.options.context||promise;if(resolveOrReject===true){dfd.resolveWith(context,args)}else{if(resolveOrReject===false){dfd.rejectWith(context,args)}}promise.abort=dfd.promise;return this._enhancePromise(promise)},_addConvenienceMethods:function(e,data){var that=this,getPromise=function(args){return $.Deferred().resolveWith(that,args).promise()};data.process=function(resolveFunc,rejectFunc){if(resolveFunc||rejectFunc){data._processQueue=this._processQueue=(this._processQueue||getPromise([this])).pipe(function(){if(data.errorThrown){return $.Deferred().rejectWith(that,[data]).promise()}return getPromise(arguments)}).pipe(resolveFunc,rejectFunc)}return this._processQueue||getPromise([this])};data.submit=function(){if(this.state()!=="pending"){data.jqXHR=this.jqXHR=(that._trigger("submit",$.Event("submit",{delegatedEvent:e}),this)!==false)&&that._onSend(e,this)}return this.jqXHR||that._getXHRPromise()};data.abort=function(){if(this.jqXHR){return this.jqXHR.abort()}this.errorThrown="abort";that._trigger("fail",null,this);return that._getXHRPromise(false)};data.state=function(){if(this.jqXHR){return that._getDeferredState(this.jqXHR)}if(this._processQueue){return that._getDeferredState(this._processQueue)}};data.processing=function(){return !this.jqXHR&&this._processQueue&&that._getDeferredState(this._processQueue)==="pending"};data.progress=function(){return this._progress};data.response=function(){return this._response
}},_getUploadedBytes:function(jqXHR){var range=jqXHR.getResponseHeader("Range"),parts=range&&range.split("-"),upperBytesPos=parts&&parts.length>1&&parseInt(parts[1],10);return upperBytesPos&&upperBytesPos+1},_chunkedUpload:function(options,testOnly){options.uploadedBytes=options.uploadedBytes||0;var that=this,file=options.files[0],fs=file.size,ub=options.uploadedBytes,mcs=options.maxChunkSize||fs,slice=this._blobSlice,dfd=$.Deferred(),promise=dfd.promise(),jqXHR,upload;if(!(this._isXHRUpload(options)&&slice&&(ub||mcs<fs))||options.data){return false}if(testOnly){return true}if(ub>=fs){file.error=options.i18n("uploadedBytes");return this._getXHRPromise(false,options.context,[null,"error",file.error])}upload=function(){var o=$.extend({},options),currentLoaded=o._progress.loaded;o.blob=slice.call(file,ub,ub+mcs,file.type);o.chunkSize=o.blob.size;o.contentRange="bytes "+ub+"-"+(ub+o.chunkSize-1)+"/"+fs;that._initXHRData(o);that._initProgressListener(o);jqXHR=((that._trigger("chunksend",null,o)!==false&&$.ajax(o))||that._getXHRPromise(false,o.context)).done(function(result,textStatus,jqXHR){ub=that._getUploadedBytes(jqXHR)||(ub+o.chunkSize);if(currentLoaded+o.chunkSize-o._progress.loaded){that._onProgress($.Event("progress",{lengthComputable:true,loaded:ub-o.uploadedBytes,total:ub-o.uploadedBytes}),o)}options.uploadedBytes=o.uploadedBytes=ub;o.result=result;o.textStatus=textStatus;o.jqXHR=jqXHR;that._trigger("chunkdone",null,o);that._trigger("chunkalways",null,o);if(ub<fs){upload()}else{dfd.resolveWith(o.context,[result,textStatus,jqXHR])}}).fail(function(jqXHR,textStatus,errorThrown){o.jqXHR=jqXHR;o.textStatus=textStatus;o.errorThrown=errorThrown;that._trigger("chunkfail",null,o);that._trigger("chunkalways",null,o);dfd.rejectWith(o.context,[jqXHR,textStatus,errorThrown])})};this._enhancePromise(promise);promise.abort=function(){return jqXHR.abort()};upload();return promise},_beforeSend:function(e,data){if(this._active===0){this._trigger("start");this._bitrateTimer=new this._BitrateTimer();this._progress.loaded=this._progress.total=0;this._progress.bitrate=0}this._initResponseObject(data);this._initProgressObject(data);data._progress.loaded=data.loaded=data.uploadedBytes||0;data._progress.total=data.total=this._getTotal(data.files)||1;data._progress.bitrate=data.bitrate=0;this._active+=1;this._progress.loaded+=data.loaded;this._progress.total+=data.total},_onDone:function(result,textStatus,jqXHR,options){var total=options._progress.total,response=options._response;if(options._progress.loaded<total){this._onProgress($.Event("progress",{lengthComputable:true,loaded:total,total:total}),options)}response.result=options.result=result;response.textStatus=options.textStatus=textStatus;response.jqXHR=options.jqXHR=jqXHR;this._trigger("done",null,options)},_onFail:function(jqXHR,textStatus,errorThrown,options){var response=options._response;if(options.recalculateProgress){this._progress.loaded-=options._progress.loaded;this._progress.total-=options._progress.total}response.jqXHR=options.jqXHR=jqXHR;response.textStatus=options.textStatus=textStatus;response.errorThrown=options.errorThrown=errorThrown;this._trigger("fail",null,options)},_onAlways:function(jqXHRorResult,textStatus,jqXHRorError,options){this._trigger("always",null,options)},_onSend:function(e,data){if(!data.submit){this._addConvenienceMethods(e,data)}var that=this,jqXHR,aborted,slot,pipe,options=that._getAJAXSettings(data),send=function(){that._sending+=1;options._bitrateTimer=new that._BitrateTimer();jqXHR=jqXHR||(((aborted||that._trigger("send",$.Event("send",{delegatedEvent:e}),options)===false)&&that._getXHRPromise(false,options.context,aborted))||that._chunkedUpload(options)||$.ajax(options)).done(function(result,textStatus,jqXHR){that._onDone(result,textStatus,jqXHR,options)}).fail(function(jqXHR,textStatus,errorThrown){that._onFail(jqXHR,textStatus,errorThrown,options)}).always(function(jqXHRorResult,textStatus,jqXHRorError){that._onAlways(jqXHRorResult,textStatus,jqXHRorError,options);that._sending-=1;that._active-=1;if(options.limitConcurrentUploads&&options.limitConcurrentUploads>that._sending){var nextSlot=that._slots.shift();while(nextSlot){if(that._getDeferredState(nextSlot)==="pending"){nextSlot.resolve();break}nextSlot=that._slots.shift()}}if(that._active===0){that._trigger("stop")}});return jqXHR};this._beforeSend(e,options);if(this.options.sequentialUploads||(this.options.limitConcurrentUploads&&this.options.limitConcurrentUploads<=this._sending)){if(this.options.limitConcurrentUploads>1){slot=$.Deferred();this._slots.push(slot);pipe=slot.pipe(send)}else{this._sequence=this._sequence.pipe(send,send);pipe=this._sequence}pipe.abort=function(){aborted=[undefined,"abort","abort"];if(!jqXHR){if(slot){slot.rejectWith(options.context,aborted)}return send()}return jqXHR.abort()};return this._enhancePromise(pipe)}return send()},_onAdd:function(e,data){var that=this,result=true,options=$.extend({},this.options,data),files=data.files,filesLength=files.length,limit=options.limitMultiFileUploads,limitSize=options.limitMultiFileUploadSize,overhead=options.limitMultiFileUploadSizeOverhead,batchSize=0,paramName=this._getParamName(options),paramNameSet,paramNameSlice,fileSet,i,j=0;
if(!filesLength){return false}if(limitSize&&files[0].size===undefined){limitSize=undefined}if(!(options.singleFileUploads||limit||limitSize)||!this._isXHRUpload(options)){fileSet=[files];paramNameSet=[paramName]}else{if(!(options.singleFileUploads||limitSize)&&limit){fileSet=[];paramNameSet=[];for(i=0;i<filesLength;i+=limit){fileSet.push(files.slice(i,i+limit));paramNameSlice=paramName.slice(i,i+limit);if(!paramNameSlice.length){paramNameSlice=paramName}paramNameSet.push(paramNameSlice)}}else{if(!options.singleFileUploads&&limitSize){fileSet=[];paramNameSet=[];for(i=0;i<filesLength;i=i+1){batchSize+=files[i].size+overhead;if(i+1===filesLength||((batchSize+files[i+1].size+overhead)>limitSize)||(limit&&i+1-j>=limit)){fileSet.push(files.slice(j,i+1));paramNameSlice=paramName.slice(j,i+1);if(!paramNameSlice.length){paramNameSlice=paramName}paramNameSet.push(paramNameSlice);j=i+1;batchSize=0}}}else{paramNameSet=paramName}}}data.originalFiles=files;$.each(fileSet||files,function(index,element){var newData=$.extend({},data);newData.files=fileSet?element:[element];newData.paramName=paramNameSet[index];that._initResponseObject(newData);that._initProgressObject(newData);that._addConvenienceMethods(e,newData);result=that._trigger("add",$.Event("add",{delegatedEvent:e}),newData);return result});return result},_replaceFileInput:function(data){var input=data.fileInput,inputClone=input.clone(true),restoreFocus=input.is(document.activeElement);data.fileInputClone=inputClone;$("<form></form>").append(inputClone)[0].reset();input.after(inputClone).detach();if(restoreFocus){inputClone.focus()}$.cleanData(input.unbind("remove"));this.options.fileInput=this.options.fileInput.map(function(i,el){if(el===input[0]){return inputClone[0]}return el});if(input[0]===this.element[0]){this.element=inputClone}},_handleFileTreeEntry:function(entry,path){var that=this,dfd=$.Deferred(),errorHandler=function(e){if(e&&!e.entry){e.entry=entry}dfd.resolve([e])},successHandler=function(entries){that._handleFileTreeEntries(entries,path+entry.name+"/").done(function(files){dfd.resolve(files)}).fail(errorHandler)},readEntries=function(){dirReader.readEntries(function(results){if(!results.length){successHandler(entries)}else{entries=entries.concat(results);readEntries()}},errorHandler)},dirReader,entries=[];path=path||"";if(entry.isFile){if(entry._file){entry._file.relativePath=path;dfd.resolve(entry._file)}else{entry.file(function(file){file.relativePath=path;dfd.resolve(file)},errorHandler)}}else{if(entry.isDirectory){dirReader=entry.createReader();readEntries()}else{dfd.resolve([])}}return dfd.promise()},_handleFileTreeEntries:function(entries,path){var that=this;return $.when.apply($,$.map(entries,function(entry){return that._handleFileTreeEntry(entry,path)})).pipe(function(){return Array.prototype.concat.apply([],arguments)})},_getDroppedFiles:function(dataTransfer){dataTransfer=dataTransfer||{};var items=dataTransfer.items;if(items&&items.length&&(items[0].webkitGetAsEntry||items[0].getAsEntry)){return this._handleFileTreeEntries($.map(items,function(item){var entry;if(item.webkitGetAsEntry){entry=item.webkitGetAsEntry();if(entry){entry._file=item.getAsFile()}return entry}return item.getAsEntry()}))}return $.Deferred().resolve($.makeArray(dataTransfer.files)).promise()},_getSingleFileInputFiles:function(fileInput){fileInput=$(fileInput);var entries=fileInput.prop("webkitEntries")||fileInput.prop("entries"),files,value;if(entries&&entries.length){return this._handleFileTreeEntries(entries)}files=$.makeArray(fileInput.prop("files"));if(!files.length){value=fileInput.prop("value");if(!value){return $.Deferred().resolve([]).promise()}files=[{name:value.replace(/^.*\\/,"")}]}else{if(files[0].name===undefined&&files[0].fileName){$.each(files,function(index,file){file.name=file.fileName;file.size=file.fileSize})}}return $.Deferred().resolve(files).promise()},_getFileInputFiles:function(fileInput){if(!(fileInput instanceof $)||fileInput.length===1){return this._getSingleFileInputFiles(fileInput)}return $.when.apply($,$.map(fileInput,this._getSingleFileInputFiles)).pipe(function(){return Array.prototype.concat.apply([],arguments)})},_onChange:function(e){var that=this,data={fileInput:$(e.target),form:$(e.target.form)};this._getFileInputFiles(data.fileInput).always(function(files){data.files=files;if(that.options.replaceFileInput){that._replaceFileInput(data)}if(that._trigger("change",$.Event("change",{delegatedEvent:e}),data)!==false){that._onAdd(e,data)}})},_onPaste:function(e){var items=e.originalEvent&&e.originalEvent.clipboardData&&e.originalEvent.clipboardData.items,data={files:[]};if(items&&items.length){$.each(items,function(index,item){var file=item.getAsFile&&item.getAsFile();if(file){data.files.push(file)}});if(this._trigger("paste",$.Event("paste",{delegatedEvent:e}),data)!==false){this._onAdd(e,data)}}},_onDrop:function(e){e.dataTransfer=e.originalEvent&&e.originalEvent.dataTransfer;var that=this,dataTransfer=e.dataTransfer,data={};if(dataTransfer&&dataTransfer.files&&dataTransfer.files.length){e.preventDefault();
this._getDroppedFiles(dataTransfer).always(function(files){data.files=files;if(that._trigger("drop",$.Event("drop",{delegatedEvent:e}),data)!==false){that._onAdd(e,data)}})}},_onDragOver:getDragHandler("dragover"),_onDragEnter:getDragHandler("dragenter"),_onDragLeave:getDragHandler("dragleave"),_initEventHandlers:function(){if(this._isXHRUpload(this.options)){this._on(this.options.dropZone,{dragover:this._onDragOver,drop:this._onDrop,dragenter:this._onDragEnter,dragleave:this._onDragLeave});this._on(this.options.pasteZone,{paste:this._onPaste})}if($.support.fileInput){this._on(this.options.fileInput,{change:this._onChange})}},_destroyEventHandlers:function(){this._off(this.options.dropZone,"dragenter dragleave dragover drop");this._off(this.options.pasteZone,"paste");this._off(this.options.fileInput,"change")},_setOption:function(key,value){var reinit=$.inArray(key,this._specialOptions)!==-1;if(reinit){this._destroyEventHandlers()}this._super(key,value);if(reinit){this._initSpecialOptions();this._initEventHandlers()}},_initSpecialOptions:function(){var options=this.options;if(options.fileInput===undefined){options.fileInput=this.element.is('input[type="file"]')?this.element:this.element.find('input[type="file"]')}else{if(!(options.fileInput instanceof $)){options.fileInput=$(options.fileInput)}}if(!(options.dropZone instanceof $)){options.dropZone=$(options.dropZone)}if(!(options.pasteZone instanceof $)){options.pasteZone=$(options.pasteZone)}},_getRegExp:function(str){var parts=str.split("/"),modifiers=parts.pop();parts.shift();return new RegExp(parts.join("/"),modifiers)},_isRegExpOption:function(key,value){return key!=="url"&&$.type(value)==="string"&&/^\/.*\/[igm]{0,3}$/.test(value)},_initDataAttributes:function(){var that=this,options=this.options,data=this.element.data();$.each(this.element[0].attributes,function(index,attr){var key=attr.name.toLowerCase(),value;if(/^data-/.test(key)){key=key.slice(5).replace(/-[a-z]/g,function(str){return str.charAt(1).toUpperCase()});value=data[key];if(that._isRegExpOption(key,value)){value=that._getRegExp(value)}options[key]=value}})},_create:function(){this._initDataAttributes();this._initSpecialOptions();this._slots=[];this._sequence=this._getXHRPromise(true);this._sending=this._active=0;this._initProgressObject(this);this._initEventHandlers()},active:function(){return this._active},progress:function(){return this._progress},add:function(data){var that=this;if(!data||this.options.disabled){return}if(data.fileInput&&!data.files){this._getFileInputFiles(data.fileInput).always(function(files){data.files=files;that._onAdd(null,data)})}else{data.files=$.makeArray(data.files);this._onAdd(null,data)}},send:function(data){if(data&&!this.options.disabled){if(data.fileInput&&!data.files){var that=this,dfd=$.Deferred(),promise=dfd.promise(),jqXHR,aborted;promise.abort=function(){aborted=true;if(jqXHR){return jqXHR.abort()}dfd.reject(null,"abort","abort");return promise};this._getFileInputFiles(data.fileInput).always(function(files){if(aborted){return}if(!files.length){dfd.reject();return}data.files=files;jqXHR=that._onSend(null,data);jqXHR.then(function(result,textStatus,jqXHR){dfd.resolve(result,textStatus,jqXHR)},function(jqXHR,textStatus,errorThrown){dfd.reject(jqXHR,textStatus,errorThrown)})});return this._enhancePromise(promise)}data.files=$.makeArray(data.files);if(data.files.length){return this._onSend(null,data)}}return this._getXHRPromise(false,data&&data.context)}})}));

(function(){
	$.rendUploader=function(id){  
		$(id).fileupload({
			url: CONST_UPLOAD,
			dataType: 'json',
			done: function (e, data) {
				var $result=data.result;
				if($result.status==1){ 
					var $parent=$(id).parent().parent().parent().find("input[type!='file']"); 
					if($parent.length>0){
						$parent.val($result.info); 
					}
					var $name = $parent.attr("data-image");
					if($name!='undefined'){
						$($name).attr("src",$result.info);
					}
					var $action = $(id).attr("data-action");
					if($action=='reload'){
						location.reload();
					}
					
				}else{
					alerterr($result.info);	
				} 
			},
			progressall: function (e, data) { 
			}
		}); 
	};
	
	 
})(jQuery);
$(function(){
	$("body").on("mouseenter",".fileinput",function(){
		var o=$(this).parent().parent().find("input");
		 var img=o.val();
		 var html ="<div id=\"hoverimg\"><img src=\""+img+"\" alt=\"\"/></div>";
		 if($.trim(img)!=""){  
			 if($("#hoverimg").length==0){
				 $(html).appendTo($("body")); 
			 }
				var v=img.substr(img.length-3,3).toLowerCase();
				if(v=="jpg" || v=="gif" || v=="png" || v=="bmp"){
				$("#hoverimg").html("<img src=\""+img+"\" alt=\"\"/>");
				$("#hoverimg").css({"left":o.offset().left,"top":o.offset().top+37}).show()
				}
			 }
	});
	$("body").on("mouseleave",".fileinput",function(){
	  $("#hoverimg").hide();
	});
	
	
	$("body").on("click",".removeupload",function(){
		var that=$(this).parent().parent().find("input[type='text']");
		if(that.val()!=""){
		layer.confirm("确定清除吗?",{title:'系统提示'}, function(index) {
			that.val("");  
			layer.close(index);
		});
		}
			
	});
	
});
