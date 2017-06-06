
$('#ins').on('change', function() {
    console.log($(this).val());
});
$('#courses').on('change', function() {
    console.log($(this).val());
});

// Questions page select options

$('#topi').on('change', function() {
    console.log($(this).val());
});
$('#coursesQ').on('change', function() {
    console.log($(this).val());
});


$('#lvl').on('change', function() {
    console.log($(this).val());
});
$('#typeofQuestion').change( function() {
    console.log($(this).val());
});


function MainFormAddQuestion () {
 console.log("click");
     var htmlString = "";

   if ($('#typeofQuestion').val()=="MCQ") {
   		htmlString = MCQ();
   		}
   if ($('#typeofQuestion').val()=="True/Flase") {
	htmlString += TrueFlase();  
		}
   if ($('#typeofQuestion').val()=="Comprehension") {
   		htmlString += Comprehension();
   }
   if ($('#typeofQuestion').val()=="MultiMedia") {
   		console.log("MultiMedia");
   		htmlString += Comprehension();

   }
   if ($('#typeofQuestion').val()=="Editorail/Code") {
   	console.log("Editorail/Code");
	htmlString += Editorial();

   }
   else {
   	console.log("select question type to proceed") 
   }
  

  $("#outputArea").append(htmlString);
}

function ComprehensionMultiMedia () {
 console.log("click");
     var htmlString = "";

   if ( $('#EditorialQuestionTypeSelect').val()=="MCQ") {
   		htmlString = MCQ();
   		}
   if ($('#EditorialQuestionTypeSelect').val()=="True/Flase") {
	htmlString += TrueFlase();  
		}
   else {
   	console.log("select question type to proceed") 
   }
  

  $("#outputArea2").append(htmlString);
}

function MCQ (content) {
	// body... 
	 content+="<div class='row'>"
   					+"<p> please enter MCQ question below: </p>"	
				+"<form>" 
    				+"<div class='form-group'>"
	    				+"<div class='col-lg-6 col-xs-12'>"
      						+"<textarea class='form-control' placehoder='Enter MCQ question here' rows='2' id='MCQ'></textarea>"
	    				+"</div>"
	    				+"<div class='col-lg-6 col-xs-12'>"
		    				+"<input type='checkbox' id='A1' />" 
		    				+"<input type='text' placehoder='Answer 1' id='A1Text'/>"
	    				+"</div>"
	    				+"<div class='pull-right col-lg-6 col-xs-12' >"
		    				+"<input type='checkbox' id='A2' />" 
		    				+"<input type='text' placehoder='Answer 2' id='A2Text'/>"
	    				+"</div>"
	    				+"<div class='col-lg-6 col-xs-12'>"
		    				+"<input type='checkbox' id='A3'/>" 
		    				+"<input type='text' placehoder='Answer 3'/>"
	    				+"</div>"
	    				+"<div class='pull-right col-lg-6 col-xs-12' >"
		    				+"<input type='checkbox' id='A4' />" 
		    				+"<input type='text' placehoder='Answer 4'/>"  
    					+"</div>"
    				+"</div>" 
					+"<a class='btn btn-add' id='btnAddQuestToDB' onClick='AddQuestToDB'>Add Question To DB</a>"
				+"</form>"
			+"</div>"
		return content ;
};
function TrueFlase (content) {
	// body... 
	content+= "<div class='row'>"
   					+"<p> please enter True/Flase question below: </p>"	
				+"<form>" 
    				+"<div class='form-group'>"
	    				+"<div class='col-lg-6 col-xs-12'>"
      						+"<textarea class='form-control' placehoder='Enter True/Flase question here' rows='2' id='TF'></textarea>"
	    				+"</div>"
	    				+"<div class='col-lg-6 col-xs-12'>"
		    				+"<input type='checkbox' id='A1' />" 
		    				+"<input type='text' placehoder='Answer 1' id='A1Text'/>"
	    				+"</div>"
	    				+"<div class='pull-right col-lg-6 col-xs-12' >"
		    				+"<input type='checkbox' id='A2' />" 
		    				+"<input type='text' placehoder='Answer 2' id='A2Text'/>"
	    				+"</div>"
    				+"</div>" 
				+"<a class='btn btn-add' id='btnAddQuestToDB' onClick='AddQuestToDB'>Add Question To DB</a>"
				+"</form>"
			+"</div>" 
			return content;
};

function Comprehension (content) {
	// body... 
	content+= 
			"<div class='row'>"
   					+"<p> please enter Comprehension/MultiMedia question below: </p>"	
				+"<form>" 
    				+"<div class='form-group'>"
	    				+"<div class='col-lg-6 col-xs-12'>"
      						+"<textarea class='form-control' placehoder='Enter Editoral/Code question here' rows='2' id='Editorial'></textarea>"
	    				+"</div>"
	    				+"<div class='col-lg-6 col-xs-12'>"
	    				+"<p class='text-info bg-info'> Please Select Type of Question you want to add to Editorial/Code Question</p>"
	    				+"</div>"	
                		+"<div class='pull-left col-lg-6 col-xs-12'>"
							+"<div class='input-group input-group-sm '>"
			                        +"<select class='form-control' id='lvl'>"
			                            +"<option value='' disabled selected>Select Difficulty</option>"
			                            +"<option value='1'>Easy</option>"
			                            +"<option value='2'>Meduim</option>"
			                            +"<option value='3'>Hard</option>"
			                       +" </select>"
			                   +" </div>"
	                   	+"</div>"
                		+"<div class='pull-right col-lg-6 col-xs-12'>"
		                   +"<div class='input-group input-group-sm col-lg-6 col-xs-12'>"
		                        +"<select class='form-control C' id='EditorialQuestionTypeSelect'' >"
		                            +"<option value='' disabled selected>Select Question Type</option>"
		                            +"<option data-contentId='MCQ' value='MCQ'>MCQ</option>"
		                            +"<option data-contentId='TF' value='True/Flase'>True/Flase</option>"
		                       +" </select>"
		                   +" </div>"	    				
	                   +" </div>"	    				
                   +" </div>"
                   +"<div class='text-center'>"
                  	+"<a class='btn btn-add' id='SubBtn' onClick='ComprehensionMultiMedia()'>Add Sub Question</a>"
      			  +"</div>"
				+"</form>"
			+"</div>" 
			
			return content;
};
function Editorial (content) {
	// body... 
	 content+="<div class='row'>"
   					+"<p> please enter Editorial question below: </p>"	
				+"<form>" 
    				+"<div class='form-group'>"
	    				+"<div class='col-lg-6 col-xs-12'>"
      						+"<textarea class='form-control' placehoder='Enter MCQ question here' rows='2' id='MCQ'></textarea>"
	    				+"</div>"
    				+"</div>" 
				+"<a class='btn btn-add' id='btnAddQuestToDB' onClick='AddQuestToDB'>Add Question To DB</a>"
			+"</form>"
			+"</div>"
			return content ;
};
