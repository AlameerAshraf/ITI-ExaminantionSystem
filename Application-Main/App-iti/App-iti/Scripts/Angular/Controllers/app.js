var app = angular.module("Examination",['moment-picker']);

app.controller("DepartmentController", function($scope){
    
    $scope.searchforDept;

    $scope.departments = [
        {
            "id": 1,
            "name": "Professional Developement",
            "value": false
        },
        {
            "id": 2,
            "name": "Web & Mobile Developement",
            "value": false
        },
        {
            "id": 3,
            "name": "User Interface",
            "value": false
        },
        {
            "id": 4,
            "name": "System Administrator ",
            "value": false
        },
        {
            "id": 5,
            "name": "Nano Developement",
            "value": false
        },
        {
            "id": 6,
            "name": "Software Testing",
            "value": false
        },
        {
            "id": 7,
            "name": "Robot Development",
            "value": false
        }

    ];
$scope.exams = [
        {
            "id": 1,
            "status": true,
            "name": "C#",
            "CrsCode": "cSharp",
            "instructor": "AlAmeer",
            "platformIntake": 37,
            "examDate": "2017-09-23T18:00:37-07:00"
        },
        {
            "id": 2,
            "status": false,
            "name": "Java",
            "CrsCode": "Java",
            "instructor": "Hani",
            "platformIntake": 37,
            "examDate": "2017-12-28T06:02:56-08:00"
        },
        {
            "id": 3,
            "status": true,
            "name": "Javascript",
            "CrsCode": "Java",
            "platformIntake": 37,
            "instructor": "Arsany",
            "examDate": "2017-07-30T09:00:15-07:00"
        }

    ];
    $scope.grades=[
       {
        studentName: "Eman Mohammed", 
        studentId:100,
        details:[
         {department: "User interface",
          departmentId: 5, 
          platformIntake:37,
          Course:"Photoshop",
          CourseID:"PS",
          Grade:"A",
          },
        ]},
        {
        studentName: "Eman Mohammed", 
        studentId:100,
        details:[
         {department: "User interface",
          departmentId: 5, 
          platformIntake:37,
          Course:"Photoshop",
          CourseID:"PS",
          Grade:"A",
          },
        ]},
        
    ];
        
    
    $scope.locationNames=[
      {id: "cSharp",value: "C#", 
       details:[
         {department: "Professional Developement",departmentId: 1, platformIntake:30},
         {department: "Professional Developement",departmentId: 1, platformIntake:38},
         {department: "Professional Developement",departmentId: 1, platformIntake:18},
         {department: "Professional Developement",departmentId: 1, platformIntake:28},
         {department: "Professional Developement",departmentId: 1, platformIntake:48},
      ]},

      {id: "Java",value: "Java", 
       details:[
         {department: "Web & Mobile Developement",departmentId: 2, platformIntake:30},
         {department: "Web & Mobile Developement",departmentId: 2, platformIntake:38},
         {department: "Web & Mobile Developement",departmentId: 2, platformIntake:18},
         {department: "Web & Mobile Developement",departmentId: 2, platformIntake:28},
         {department: "Web & Mobile Developement",departmentId: 2, platformIntake:48},
      ]},
      {id: "AE",value: "After Effects", 
       details:[
         {department: "User interface",departmentId: 3}
      ]},
      {id: "ISQTB",value: "ISQTB Foundation", 
       details:[
         {department: "Software Testing",departmentId: 6}
      ]},
      {id: "FoF",value: "Foundation of things", 
       details:[
         {department: "Nano Developement",departmentId: 5}
      ]},
      {id: "Linx",value: "Linux", 
       details:[
         {department: "System Administrator",departmentId: 4}
      ]},
      {id: "Js",value: "Javascript", 
        details:[
        {department: "Open Source",departmentId: 7}
        ]}

    ];

    $scope.incidentTypesList={
        cSharp: [
            { id: "1", value: "AlAmeer Asharf" },
            { id: "2", value: "Hani Sawfat" },
            { id: "3", value: "Mahmoud Ouf" }
        ],
        AE: [
            { id: "1", value: "AlAmeer Mohammed" },
            { id: "2", value: "Madonna Sawfat" },
            { id: "3", value: "Ali Ouf" }
        ],
        ISQTB: [
            { id: "1", value: "Arsany Nagy Asharf" },
            { id: "2", value: "Hani Adel" },
            { id: "3", value: "Mahmoud Aly" }
        ],

        FoF: [
            { id: "1", value: "Mustafa Habliza" },
            { id: "2", value: "Hani Gad" },
            { id: "3", value: "Hadeer Ouf" }
        ],
        Linx: [
            { id: "1", value: "AlAmeer Asharf" },
            { id: "2", value: "Hani Sawfat" },
            { id: "3", value: "Mahmoud Ouf" }
        ],
        Js: [
            { id: "1", value: "Eman Mohammed " },
            { id: "2", value: "Albert Sawfat" },
            { id: "3", value: "Albert Moirries" }
        ],
        Java: [
            { id: "1", value: "Ghada Qaduos" },
            { id: "2", value: "Mohammed Rezek" },
            { id: "3", value: "Nasar Manosura" }
        ]
    };

    
  
});
app.controller('QuestionController', function ($scope) {

  $scope.courses=[
    {id: "cSharp",value: "C#", 
       details:[
         {department: "Professional Developement",departmentId: 1, platformIntake:30},
         {department: "Professional Developement",departmentId: 1, platformIntake:38},
         {department: "Professional Developement",departmentId: 1, platformIntake:18},
         {department: "Professional Developement",departmentId: 1, platformIntake:28},
         {department: "Professional Developement",departmentId: 1, platformIntake:48},
      ]},

      {id: "Java",value: "Java", 
       details:[
         {department: "Web & Mobile Developement",departmentId: 2, platformIntake:30},
         {department: "Web & Mobile Developement",departmentId: 2, platformIntake:38},
         {department: "Web & Mobile Developement",departmentId: 2, platformIntake:18},
         {department: "Web & Mobile Developement",departmentId: 2, platformIntake:28},
         {department: "Web & Mobile Developement",departmentId: 2, platformIntake:48},
      ]}
  ];
  $scope.topics={
    cSharp: [
            { id: "1", value: "Loops" },
            { id: "2", value: "Arrays" },
            { id: "3", value: "Conditions" }
        ],
        Java: [
            { id: "1", value: "Loops"  },
            { id: "2", value: "Arrays"  },
            { id: "3", value: "Conditions"}
        ]
    };
  $scope.typeofQuestions=[
            {
              id:1,
              type:"MCQ"
            },
            {
              id:2,
              type:"True/Flase"
            },
            {
              id:3,
              type:"Editorail/Code"
            },
            {
              id:4,
              type:"Multimedia"
            },
  ];
   $scope.LevelOfDiffculty=[
            {
              id:1,
              type:"Easy"
            },
            {
              id:2,
              type:"Meduim"
            },
            {
              id:3,
              type:"Hard"
            }
  ];
  $scope.questions = [
        {
            id: "cSharp",
            value: "C#",
            details: [{
                    Question: " Which of the following converts a type to a single Unicode character, where possible in C#?",
                    Type: "MCQ",
                    answers: [{
                        1: "A - ToSingle",
                        2: "B - ToByte",
                        3: "C - ToChar",
                        4: "D - ToDateTime"
                    }],
                    correctAnswer: 3
                }, {
                    Question: "Which of the following variable types can be assigned a value directly in C#",
                    Type: "MCQ",
                    answers: [{
                        1: "A - Value types",
                        2: "B - Reference types",
                        3: "C - Pointer types",
                        4: "D - All of the above"
                    }],
                    correctAnswer: 1
                },

            ]//END DETAILS
        }, //end C#
        {
            id: "Java",
            value: "Java",
            details: [{
                    Question: "Which of the following is correct about System.out::println expression?",
                    Type: "MCQ",
                    answers: [{
                        1: "A - System.out::println method is a static method reference to println method of out object of System class.",
                        2: "B - System.out::println method is a instance method reference to println method of out object of System class.",
                        3: "C - Both of the above.s",
                        4: "D - None of the above"
                    }],
                    correctAnswer: 1
                }, {
                    Question: "Which of the following functional interface represents a function that accepts a double-valued argument and produces an int-valued result?",
                    Type: "MCQ",
                    answers: [{
                        1: "A - DoubleFunction<R>",
                        2: "B - DoublePredicate",
                        3: "C - DoubleSupplier",
                        4: "D - DoubleToIntFunction"
                    }],
                    correctAnswer: 1
                },

            ]//end details
        }//end java
      ]//end question
      
$scope.changedValue=function(){
console.log($scope.question)
  }
  
});