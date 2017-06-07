
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
	 content='<div class="row">'
   		
        +'<form col-lg-12>'

        +"<div class='form-group'>"
        +"<div class='col-lg-6 col-xs-12'>"
       
        +"<h5 class='titles-answer-mcq'> Please Enter MCQ Question Below : </h5>"	
    
        +"<textarea class='form-control' placehoder='Enter MCQ question here' rows='2' id='MCQ'></textarea>"
   +"</div>" 
        
 +"<div class='form-group col-lg-6'>"
        +"<h5 class='title-answer-mcq titles-answer-mcq'> Please Enter MCQ Answers Here : </h5>"
        +"<div class='col-lg-6 col-xs-12'>"

        +"<input type='checkbox' id='A1' />   " 
        +"<input type='text' placeholder='Answer 1' id='A1Text'/>"
        
       +"</div>"

        +"<div class='pull-right col-lg-6 col-xs-12' >"
        
        +"<input type='checkbox' id='A2' />   "
       +"<input type='text' placeholder='Answer 2' id='A2Text'/>"
        
        +"</div>"
            +"</div>"
    +'<div class="form-group col-lg-6">'

        +"<div class='col-lg-6 col-xs-12'>"
        
        +"<input type='checkbox' id='A3'/>   "
        +"<input type='text' placeholder='Answer 3'/>"
        
        +"</div>"

        +"<div class='pull-right col-lg-6 col-xs-12' >"
        
        +"<input type='checkbox' id='A4' />   "
        +"<input type='text' placeholder='Answer 4'/>" 
        
        +"</div>"

            +'</div>'
        +'</div>'

        +'</form>'



        +"</div>"
          +'<div class="btn-addquestion text-center">'
           +" <a class='btn btn-add' id='btnAddQuestToDB' onClick='AddQuestToDB'>Add Question To DB</a>"

+"</div>"
		return content ;
};
function TrueFlase (content) {
	// body... 
	content= '<div class="row">'
   		
        +'<form col-lg-12>'

        +"<div class='form-group'>"
        +"<div class='col-lg-6 col-xs-12'>"
       
      +"<h5 class='titles-answer-mcq'> please enter True/Flase question below: </h5>"	+"<textarea class='form-control' placeholder='Enter True/Flase question here' rows='2' id='TF'></textarea>"
      
   +"</div>" 
        
 +"<div class='form-group col-lg-6'>"
        +"<h5 class='title-answer-mcq titles-answer-mcq'> Please Enter true Answers Here : </h5>"
        +"<div class='col-lg-6 col-xs-12'>"

       	+"<input type='checkbox' id='A1' />        " 
        +"<input type='text' placeholder='True Case' id='A1Text'/>"
        +"</div>"
	
        
            +"</div>"
 
        +'</div>'

        +'</form>'



        +"</div>"
          +'<div class="btn-addquestion text-center">'
           +" <a class='btn btn-add' id='btnAddQuestToDB' onClick='AddQuestToDB'>Add Question To DB</a>"

+"</div>"
			return content;
};

function Comprehension (content) {
	// body... 
	content= 
			'<div class="row">'
   		
        +'<form col-lg-12>'

        +"<div class='form-group'>"
        	+"<div class='col-lg-6 col-xs-12'>"
     +"<h5 class='titles-answer-mcq'> please enter Comprehension/MultiMedia question below: </h5>"	
     +"<textarea class='form-control' placehoder='Enter Editoral/Code question here' rows='2' id='Editorial'></textarea>"
     +"</div>"
        +'</div>'
        
        
        	+"<div class='col-lg-6 col-xs-12'>"
	    				+"<h5 class='titles-answer-mcq'> Please Select Type of Question you want to add to Editorial/Code Question</h5>"
	    				+"</div>"	
                		+"<div class='pull-left col-lg-6 col-xs-12'>"
     +"<div class='form-group'>"
							+"<div class='input-group input-group-sm '>"
			                        +"<select class='form-control' id='lvl'>"
			                            +"<option value='' disabled selected>Select Difficulty</option>"
			                            +"<option value='1'>Easy</option>"
			                            +"<option value='2'>Meduim</option>"
			                            +"<option value='3'>Hard</option>"
			                       +" </select>"
			                   +" </div>"
    +" </div>"
	                   	+"</div>"
                		+"<div class='pull-right col-lg-6 col-xs-12'>"
                          +"<div class='form-group'>"
		                   +"<div class='input-group input-group-sm col-lg-6 col-xs-12'>"
		                        +"<select class='form-control C' id='EditorialQuestionTypeSelect'' >"
		                            +"<option value='' disabled selected>Select Question Type</option>"
		                            +"<option value='MCQ'>MCQ</option>"
		                            +"<option value='True/Flase'>True/Flase</option>"
		                       +" </select>"
		                   +" </div>"	    				
	                   +" </div>"	    				
                   +" </div>"
    +" </div>"

        +'</form>'



+"</div>"
          +'<div class="btn-addquestion text-center">'
           +" <a class='btn btn-add' id='btnAddQuestToDB' onClick='AddQuestToDB'>Add Question To DB</a>"

+"</div>"
			
			return content;
};
function Editorial (content) {
	// body... 
	 content='<div class="row">'
   		
        +'<form col-lg-12>'

        +"<div class='form-group'>"
        +"<div class='col-lg-6 col-xs-12'>"
       
      +"<h5 class='titles-answer-mcq'>please enter Editorial question below:</h5>"	
    +"<textarea class='form-control' placehoder='Enter MCQ question here' rows='2' id='MCQ'></textarea>"
      
   +"</div>" 
      
        +'</div>'

        +'</form>'



        +"</div>"
          +'<div class="btn-addquestion text-center">'
           +" <a class='btn btn-add' id='btnAddQuestToDB' onClick='AddQuestToDB'>Add Question To DB</a>"

+"</div>"
			return content ;
};
