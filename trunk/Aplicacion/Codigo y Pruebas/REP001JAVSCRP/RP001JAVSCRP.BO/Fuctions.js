//Curry Function for general purpuse
		function add (x,y) {
			return x+y;
		}

		function curry (fn) {
			// body...
			var slice = Array.prototype.slice;
			var stored_args = slice.call(arguments,1);
			console.log(stored_args);
		    	return function () {
		    		var new_args = slice.call(arguments);
		    		var args = stored_args.concat(new_args);
		    		console.log(args);
		    		return fn.apply(null,args);
		    	}
		    }
		

		//Currying Functions
		function add(x, y) {
			var oldx = x, oldy = y;
			// console.log(oldx);
			// console.log(oldy);

			if (typeof oldy === "undefined") { // partial
				return function (newy) {
					return oldx  + newy;
				};
			}
			// full application
			return x + y;
		}
		//Test Currying
		typeof add(5);
		add(3,4);
		var add200 = add(200);
		add200(10);


		//Init-Time Branching

		//Inmediate Object Initialization
		({
			width:600,
			height:400,
			gimmeMax: function(){
				return this.width+'x'+this.height;
			},
			init:function(){
				console.log(this.gimmeMax());
			}
		}).init();


		//Returning Fuctions
		var setup = function(){
			var cont =0;
			console.log(cont);

			return function(){
				return(cont+=1);
			}
		}
		var next = setup();
			next();
			next();

		//CallBacks and Scope
			var applyObj ={};
			applyObj.color="green";
			applyObj.paint = function(item){
				var element = $(item);
				element.css({'color':'red'});
			};
			applyObj.hide = function(item){
				var element = $(item);
				element.css({'display':'hide'});
			}

			var findObj = function findObj(callback,callback_obj){
				var items = $('.items');
				var nodes=[];
				var fid;
				var it = items.length;
				if( typeof callback==="string"){
					callback = callback_obj[callback];
				}
				if(typeof callback !== "function"){
					callback=false;
				}
				for (var i = 0; i < it; i++) {
					nodes.push(items[i]);
					if(i%2==0){
						if(callback){
							callback.call(callback_obj,items[i]);
						}
					}
				};
				return nodes;
			};
			
			(function ($) {
			//CallBack Simple
			/**
			 * [find patron CallBack]
			 * @param  {Function} callback [description]
			 * @return {[type]}            [description]
			 */
			var find = function find (callback) {		
				var items = $('.items');
				var nodes=[];
				var fid;
				var it = items.length;

				if(typeof callback !=='function'){
					callback=false;
				}
				for (var i = 0; i < it; i++) {
					nodes.push(items[i]);
					if(i%2==0){
						if(callback){
							callback(items[i]);
						}
						
					}
				};

				return nodes;
			};
			/**
			 * [hide patron CallBack funcion utilizada en el CallBack]
			 * @param  {[type]} item [description]
			 * @return {[type]}      [description]
			 */
			var hide = function hide (item) {
				var element = $(item);
				element.css({'color':'red'});
			};
			//find(hide);