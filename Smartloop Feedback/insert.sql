-- Year Data Insert
-- SET IDENTITY_INSERT [dbo].[year] ON
-- INSERT INTO [dbo].[year] ([name]) VALUES (2020)
-- INSERT INTO [dbo].[year] ([name]) VALUES (2024)
-- SET IDENTITY_INSERT [dbo].[year] ON

-- Student Data Insert
INSERT INTO [dbo].[student] ([studentId], [name], [email], [password], [degree]) VALUES (11111111, N'11111111', N'test@gmail.com', N'11111111', N'BA Software')
INSERT INTO [dbo].[student] ([studentId], [name], [email], [password], [degree], [profileImage]) VALUES (13888767, N'Yeran', N'13888767@gmail.com', N'yerthisev03', N'BA Software', 0xFFD8FFE000104A46494600010101000000000000FFDB0043000302020302020303030304030304050805050404050A070706080C0A0C0C0B0A0B0B0D0E12100D0E110E0B0B1016101113141515150C0F171816141812141514FFDB00430103040405040509050509140D0B0D1414141414141414141414141414141414141414)

-- Tutor Data Insert
INSERT INTO [dbo].[tutor] ([tutorId], [name], [email], [password]) VALUES (97492185, N'Mahira Mohamed Mowjoon', N'mahira.athamlebbe@uts.edu.au', N'yerthisev03')

-- Semester Data Insert
SET IDENTITY_INSERT [dbo].[semester] ON
INSERT INTO [dbo].[semester] ([id], [name], [yearName]) VALUES (1, N'Autumn', 2020)
INSERT INTO [dbo].[semester] ([id], [name], [yearName]) VALUES (7, N'Spring', 2024)
SET IDENTITY_INSERT [dbo].[semester] OFF

-- Course Data Insert
SET IDENTITY_INSERT [dbo].[course] ON
INSERT INTO [dbo].[course] ([id], [code], [name], [creditPoint], [description], [yearName], [semesterId], [canvasLink], [tutorNum]) VALUES (1, 31269, N'Business Requirements Modelling', 6, N'This subject introduces information system concepts and describes how these concepts can be used to model business requirements. It outlines how the ability to capture information about the system in ways understood by its eventual users improves the final quality of the system. An overview of agile and non-agile software engineering principles, methods, tools and techniques is presented and practised in small teams. The subject introduces various analysis approaches found in contemporary system development including object-oriented methods, agile methods, business process modelling and entity-relationship modelling. It explores the relationships between these techniques and their application, and how they are used to capture and model the business requirements. Students apply various requirements elicitation, analysis, modelling and specification techniques to case studies in small teams.', 2020, 1, N'none', 1)
INSERT INTO [dbo].[course] ([id], [code], [name], [creditPoint], [description], [yearName], [semesterId], [canvasLink], [tutorNum]) VALUES (2, 31269, N'Business Requirements Modelling', 6, N'This subject introduces information system concepts and describes how these concepts can be used to model business requirements. It outlines how the ability to capture information about the system in ways understood by its eventual users improves the final quality of the system. An overview of agile and non-agile software engineering principles, methods, tools and techniques is presented and practised in small teams. The subject introduces various analysis approaches found in contemporary system development including object-oriented methods, agile methods, business process modelling and entity-relationship modelling. It explores the relationships between these techniques and their application, and how they are used to capture and model the business requirements. Students apply various requirements elicitation, analysis, modelling and specification techniques to case studies in small teams.', 2024, 7, N'https://canvas.uts.edu.au/courses/32705/modules', 1)
SET IDENTITY_INSERT [dbo].[course] OFF

-- Assessment Data Insert
SET IDENTITY_INSERT [dbo].[assessment] ON
INSERT INTO [dbo].[assessment] ([id], [name], [description], [courseDescription], [type], [date], [weight], [mark], [canvasLink], [fileName], [fileData], [courseId])
VALUES (1,
        N'Requirements Analysis Report',
         N'Accompanying these instructions is a case study of the “Videos On The Go” company and its
Marvel Team. This case study provides enough information for you to analyse the
current customer onboarding project (e.g. activities and data) of the Marvel team by using
Business Process Modelling Notation (BPMN), Entity Relationship Diagram (ERD) and Data
Dictionary modelling and analysis techniques.
Students are required to capture necessary assumptions (e.g. a list of assumptions to support your
model and analysis) and make necessary recommendations to improve the current system (e.g. a
list of requirements or changes in the current process and data model to address any inefficiencies
that you have identified). See “Videos On The Go” Marvel Team case study section below for
details. 
',
          N'This subject introduces information system concepts and describes how these concepts can be used to model business requirements. It outlines how the ability to capture information about the system in ways understood by its eventual users improves the final quality of the system. An overview of agile and non-agile software engineering principles, methods, tools and techniques is presented and practised in small teams. The subject introduces various analysis approaches found in contemporary system development including object-oriented methods, agile methods, business process modelling and entity-relationship modelling. It explores the relationships between these techniques and their application, and how they are used to capture and model the business requirements. Students apply various requirements elicitation, analysis, modelling and specification techniques to case studies in small teams.',
           N'Report',
            N'2020-04-28',
             CAST(20.00 AS Decimal(18, 2)),
             CAST(20.00 AS Decimal(18, 2)),
             N'none',
              N'31269 BRM Autumn 2020 Assignment 1 DRAFT VERSION(1).pdf', 0x33313236392042524D20417574756D6E20323032302041737369676E6D656E74203120200A20200A554E4956455253495459204F4620544543484E4F4C4F47592C205359444E4559200A333132363920427573696E65737320526571756972656D656E7473204D6F64656C6C696E67200A41737369676E6D656E742031202D20, 1)
INSERT INTO [dbo].[assessment] ([id], [name], [description], [courseDescription], [type], [date], [weight], [mark], [canvasLink], [fileName], [fileData], [courseId])
VALUES (2,
        N'Tutorial 6',
         N'Understand and practice agile software requirement specification
approach.
? Practice developing User Stories and User Story Map.
? Practice developing acceptance criteria',
          N'This subject introduces information system concepts and describes how these concepts can be used to model business requirements. It outlines how the ability to capture information about the system in ways understood by its eventual users improves the final quality of the system. An overview of agile and non-agile software engineering principles, methods, tools and techniques is presented and practised in small teams. The subject introduces various analysis approaches found in contemporary system development including object-oriented methods, agile methods, business process modelling and entity-relationship modelling. It explores the relationships between these techniques and their application, and how they are used to capture and model the business requirements. Students apply various requirements elicitation, analysis, modelling and specification techniques to case studies in small teams.',
           N'Weekly',
            N'2024-10-09',
             CAST(7.00 AS Decimal(18, 2)),
             CAST(100.00 AS Decimal(18, 2)),
             N'https://canvas.uts.edu.au/courses/32705/files/8153909?module_item_id=2025032',
              N'Tutorial 6.pdf', 0x466163756C7479206F6620456E67696E656572696E6720616E64204954200A5363686F6F6C206F6620436F6D707574657220536369656E6365200A333132363920427573696E65737320526571756972656D656E7473204D6F64656C6C696E6720200A5765656B20373A204167696C6520446576656C6F706D656E7420776974, 1)
INSERT INTO [dbo].[assessment] ([id], [name], [description], [courseDescription], [type], [date], [weight], [mark], [canvasLink], [courseId])
VALUES (3,
        N'Short Quiz',
         N'This assessment item includes 5individual open-book short quizzes conducted on Canvas',
          N'This subject introduces information system concepts and describes how these concepts can be used to model business requirements. It outlines how the ability to capture information about the system in ways understood by its eventual users improves the final quality of the system. An overview of agile and non-agile software engineering principles, methods, tools and techniques is presented and practised in small teams. The subject introduces various analysis approaches found in contemporary system development including object-oriented methods, agile methods, business process modelling and entity-relationship modelling. It explores the relationships between these techniques and their application, and how they are used to capture and model the business requirements. Students apply various requirements elicitation, analysis, modelling and specification techniques to case studies in small teams.',
           N'Quiz',
            N'2024-10-15',
             CAST(30.00 AS Decimal(18, 2)),
             CAST(30.00 AS Decimal(18, 2)),
             N'https://canvas.uts.edu.au/courses/32705/external_tools/1990',
              2)
INSERT INTO [dbo].[assessment] ([id], [name], [description], [courseDescription], [type], [date], [weight], [mark], [canvasLink], [fileName], [fileData], [courseId])
VALUES (4,
        N'Weekly Activities',
         N'Part 1: In the first tutorial students form groups of up to five students. Students are expected to
remain in the same group for the remainder of the semester, Each week, in the tutorial, the group
will work on exercises, such as role playing, developing models, or analysing a case study, based on
the weekly lecture topic. After the completion of the tutorial, a student representative from each
group will submit the group’s completed weekly activities to Canvas by the due date on Canvas.
Each submission is worth 2% and there are ten submissions in total. Students who do not participate
as part of a group in the tutorial activities will receive zero marks for that week.
Part 2: Encouraged to submit Individual reflections in the weeks, 3 to 12 (there are 10 submissions
in total).
',
          N'This subject introduces information system concepts and describes how these concepts can be used to model business requirements. It outlines how the ability to capture information about the system in ways understood by its eventual users improves the final quality of the system. An overview of agile and non-agile software engineering principles, methods, tools and techniques is presented and practised in small teams. The subject introduces various analysis approaches found in contemporary system development including object-oriented methods, agile methods, business process modelling and entity-relationship modelling. It explores the relationships between these techniques and their application, and how they are used to capture and model the business requirements. Students apply various requirements elicitation, analysis, modelling and specification techniques to case studies in small teams.',
           N'Weekly Assessment',
            N'2024-10-15',
             CAST(20.00 AS Decimal(18, 2)),
             CAST(100.00 AS Decimal(18, 2)),
             N'https://canvas.uts.edu.au/courses/32705/files/7618062?module_item_id=1895271',
              N'Tutorial Case Study.pdf', 0x5475746F7269616C2043617365205374756479200AE28098426F6F6B69736820426C697373E280992043617365207374756479200A54686520E28098426F6F6B69736820426C697373E28099206973206120626F6F6B2072657461696C696E6720636F6D70616E7920776869636820697320736974756174656420696E206120, 2)
INSERT INTO [dbo].[assessment] ([id], [name], [description], [courseDescription], [type], [date], [weight], [mark], [canvasLink], [fileName], [fileData], [courseId])
VALUES (5,
        N'A3 - Requirements Analysis Report',
         N'The assignment case study provides information to analyse the current charter boat
project by using Business Process Modelling Notation (BPMN), Entity Relationship Diagram
(ERD) and Data Dictionary techniques.
Students should document key assumptions (e.g., a list of assumptions to support your
model and analysis) and provide recommendations for improving the current system
(e.g., a list of requirements or changes to the current process and data model to address
identified inefficiencies). Refer to the Coastal Charters (CC) case study section below for
more details
',
          N'This subject introduces information system concepts and describes how these concepts can be used to model business requirements. It outlines how the ability to capture information about the system in ways understood by its eventual users improves the final quality of the system. An overview of agile and non-agile software engineering principles, methods, tools and techniques is presented and practised in small teams. The subject introduces various analysis approaches found in contemporary system development including object-oriented methods, agile methods, business process modelling and entity-relationship modelling. It explores the relationships between these techniques and their application, and how they are used to capture and model the business requirements. Students apply various requirements elicitation, analysis, modelling and specification techniques to case studies in small teams.',
           N'Requirements Analysis Report',
            N'2024-10-15',
             CAST(20.00 AS Decimal(18, 2)),
             CAST(20.00 AS Decimal(18, 2)),
             N'https://canvas.uts.edu.au/courses/32705/assignments/194069',
              N'31269 Assessment 3.pdf', 0x466163756C7479206F6620456E67696E656572696E6720616E64204954200A5363686F6F6C206F6620436F6D707574657220536369656E6365200A333132363920427573696E65737320526571756972656D656E7473204D6F64656C6C696E67200A4173736573736D656E74203320526571756972656D656E747320416E616C, 2)
INSERT INTO [dbo].[assessment] ([id], [name], [description], [courseDescription], [type], [date], [weight], [mark], [canvasLink], [fileName], [fileData], [courseId])
VALUES (6,
        N'A4 - Requirement Specification Document',
         N'The assignment will require the students’ groups to analyse and assess the basic improvements thatthe
owners of the company mentioned in the last part of the case study andproduce an Object-Oriented Requirements
Specification report for a new and CC system. The report will include UML diagrams and parts of a software
requirement specification (SRS) document for the future improved system using the template provided on UTS
Online. Students are required to analyse and model improved system beyond the basic improvementsprovided
inthecasestudy.',
          N'This subject introduces information system concepts and describes how these concepts can be used to model business requirements. It outlines how the ability to capture information about the system in ways understood by its eventual users improves the final quality of the system. An overview of agile and non-agile software engineering principles, methods, tools and techniques is presented and practised in small teams. The subject introduces various analysis approaches found in contemporary system development including object-oriented methods, agile methods, business process modelling and entity-relationship modelling. It explores the relationships between these techniques and their application, and how they are used to capture and model the business requirements. Students apply various requirements elicitation, analysis, modelling and specification techniques to case studies in small teams.',
           N'Report',
            N'2024-10-16',
             CAST(30.00 AS Decimal(18, 2)),
             CAST(30.00 AS Decimal(18, 2)),
             N'https://canvas.uts.edu.au/courses/32705/assignments/194070',
              N'31269 Assessment 4-3.pdf', 0x466163756C7479206F6620456E67696E656572696E6720616E64204954200A5363686F6F6C206F6620436F6D707574657220536369656E6365200A333132363920427573696E65737320526571756972656D656E7473204D6F64656C6C696E67200A4173736573736D656E74203420E28093526571756972656D656E74732053, 2)
SET IDENTITY_INSERT [dbo].[assessment] OFF

-- Tutorial Data Insert
SET IDENTITY_INSERT [dbo].[tutorial] ON
INSERT INTO [dbo].[tutorial] ([id], [name], [courseId]) VALUES (1, N'1', 1)
INSERT INTO [dbo].[tutorial] ([id], [name], [courseId]) VALUES (2, N'1', 2)
SET IDENTITY_INSERT [dbo].[tutorial] OFF

-- Tutorial Association Data Insert
SET IDENTITY_INSERT [dbo].[tutorialAssociation] ON
INSERT INTO [dbo].[tutorialAssociation] ([id], [tutorialId], [generalFeedback], [isCompleted]) VALUES (1, 1, N'The students in this tutorial class have demonstrated notable advancements in their understanding of Business Process Modeling (BPM) and Entity Relationship Diagrams (ERD). The achievement of high scores, such as 19 out of 20 in Assignment Task 1, highlights their dedication and grasp of the concepts presented. Their attention to detail and thorough analysis reflect their commitment to mastering the subject matter.

Areas of Improvement:

Assumptions Alignment: Students need to ensure their assumptions are closely aligned with the case study to avoid contradictions, enhancing the coherence of their analysis.

Decision Gateways Labeling: There is a need for clearer labeling of decision gateways. Students should work on distinguishing these from actual processes to avoid confusion.

Process Clarity: Missing processes, especially those that are transformed into decision gateways, should be clearly defined to enhance the overall analysis.

Entity-Relationship Refinements: Improving the readability and logical coherence of relationships in ERDs is essential for better understanding among peers.

Data Model Enhancements: Revising relationships and cardinalities in the data model can strengthen overall analysis and provide a more robust framework.

Recommendations Clarity: Students should aim to provide clear and rational process recommendations, enriching their analyses and insights.

Suggestions for Further Improvement:

Engagement with the Case Study: Students should engage closely with the case study, ensuring all assumptions align with the provided information to enhance clarity and precision.

Practice Labeling: Encourage students to practice clear labeling of decision gateways, ensuring they understand the distinction from actual processes.

Clarification of Missing Processes: Focus on clearly defining missing processes and refining ERDs for improved readability and logical consistency.

Review of Data Model Relationships: Students should regularly review their data model relationships and cardinalities to ensure they accurately reflect underlying business processes.

Actionable Recommendations: Emphasize the importance of providing clear, actionable recommendations based on their analyses to foster deeper insights.', 1)
SET IDENTITY_INSERT [dbo].[tutorialAssociation] OFF

-- Tutorial Assessment Data Insert
SET IDENTITY_INSERT [dbo].[tutorialAssessment] ON
INSERT INTO [dbo].[tutorialAssessment] ([id], [tutorialId], [generalFeedback], [isCompleted], [assessmentId]) VALUES (1, 1, N'The students in this tutorial class have demonstrated notable advancements in their understanding of Business Process Modeling (BPM) and Entity Relationship Diagrams (ERD). The achievement of high scores, such as 19 out of 20 in Assignment Task 1, highlights their dedication and grasp of the concepts presented. Their attention to detail and thorough analysis reflect their commitment to mastering the subject matter.

Areas of Improvement:

Assumptions Alignment: Students need to ensure their assumptions are closely aligned with the case study to avoid contradictions, enhancing the coherence of their analysis.

Decision Gateways Labeling: There is a need for clearer labeling of decision gateways. Students should work on distinguishing these from actual processes to avoid confusion.

Process Clarity: Missing processes, especially those that are transformed into decision gateways, should be clearly defined to enhance the overall analysis.

Entity-Relationship Refinements: Improving the readability and logical coherence of relationships in ERDs is essential for better understanding among peers.

Data Model Enhancements: Revising relationships and cardinalities in the data model can strengthen overall analysis and provide a more robust framework.

Recommendations Clarity: Students should aim to provide clear and rational process recommendations, enriching their analyses and insights.

Suggestions for Further Improvement:

Engagement with the Case Study: Students should engage closely with the case study, ensuring all assumptions align with the provided information to enhance clarity and precision.

Practice Labeling: Encourage students to practice clear labeling of decision gateways, ensuring they understand the distinction from actual processes.

Clarification of Missing Processes: Focus on clearly defining missing processes and refining ERDs for improved readability and logical consistency.

Review of Data Model Relationships: Students should regularly review their data model relationships and cardinalities to ensure they accurately reflect underlying business processes.

Actionable Recommendations: Emphasize the importance of providing clear, actionable recommendations based on their analyses to foster deeper insights.', 1, 1)
SET IDENTITY_INSERT [dbo].[tutorialAssessment] OFF

-- Criteria Data Insert
SET IDENTITY_INSERT [dbo].[criteria] ON
INSERT INTO [dbo].[criteria] ([id], [description], [assessmentId]) VALUES (1, N'Assumptions', 1)
INSERT INTO [dbo].[criteria] ([id], [description], [assessmentId]) VALUES (2, N'Context Diagram ', 1)
INSERT INTO [dbo].[criteria] ([id], [description], [assessmentId]) VALUES (3, N'Level 1 Diagram', 1)
INSERT INTO [dbo].[criteria] ([id], [description], [assessmentId]) VALUES (4, N'Level 2 Diagrams', 1)
INSERT INTO [dbo].[criteria] ([id], [description], [assessmentId]) VALUES (5, N'Recommendations', 1)
INSERT INTO [dbo].[criteria] ([id], [description], [assessmentId]) VALUES (6, N'Entities', 1)
INSERT INTO [dbo].[criteria] ([id], [description], [assessmentId]) VALUES (7, N'Relationships', 1)
INSERT INTO [dbo].[criteria] ([id], [description], [assessmentId]) VALUES (8, N'Cardinalities', 1)
INSERT INTO [dbo].[criteria] ([id], [description], [assessmentId]) VALUES (9, N'Data Dictionary', 1)
INSERT INTO [dbo].[criteria] ([id], [description], [assessmentId]) VALUES (10, N'Correctness', 2)
INSERT INTO [dbo].[criteria] ([id], [description], [assessmentId]) VALUES (11, N'Completeness', 2)
INSERT INTO [dbo].[criteria] ([id], [description], [assessmentId]) VALUES (12, N'Correctness', 4)
INSERT INTO [dbo].[criteria] ([id], [description], [assessmentId]) VALUES (13, N'Completeness', 4)
INSERT INTO [dbo].[criteria] ([id], [description], [assessmentId]) VALUES (14, N'This criterion is linked to a learning outcomeProcess Model: Context Diagram, level 1 diagram and level 2 diagram', 5)
INSERT INTO [dbo].[criteria] ([id], [description], [assessmentId]) VALUES (15, N'Data Model: ERD and Data Dictionary', 5)
INSERT INTO [dbo].[criteria] ([id], [description], [assessmentId]) VALUES (16, N'This criterion is linked to a learning outcomeAssumptions - Process assumptions and data assumptions', 5)
INSERT INTO [dbo].[criteria] ([id], [description], [assessmentId]) VALUES (17, N'This criterion is linked to a learning outcomeRecommendations - Process recommendations and data recommendations', 5)
INSERT INTO [dbo].[criteria] ([id], [description], [assessmentId]) VALUES (18, N'This criterion is linked to a learning outcomeOverall Quality of Report Appendices, references and coversheets', 5)
INSERT INTO [dbo].[criteria] ([id], [description], [assessmentId]) VALUES (19, N'This criterion is linked to a learning outcomeStakeholder identification and Modelling', 5)
INSERT INTO [dbo].[criteria] ([id], [description], [assessmentId]) VALUES (20, N'Document Management', 6)
INSERT INTO [dbo].[criteria] ([id], [description], [assessmentId]) VALUES (21, N'Introduction', 6)
INSERT INTO [dbo].[criteria] ([id], [description], [assessmentId]) VALUES (22, N'Project Scope', 6)
INSERT INTO [dbo].[criteria] ([id], [description], [assessmentId]) VALUES (23, N'User stories', 6)
INSERT INTO [dbo].[criteria] ([id], [description], [assessmentId]) VALUES (24, N'User Story Map', 6)
INSERT INTO [dbo].[criteria] ([id], [description], [assessmentId]) VALUES (25, N'Use Case Narratives', 6)
INSERT INTO [dbo].[criteria] ([id], [description], [assessmentId]) VALUES (26, N'Sequence Diagrams', 6)
INSERT INTO [dbo].[criteria] ([id], [description], [assessmentId]) VALUES (27, N'Class Diagram', 6)
INSERT INTO [dbo].[criteria] ([id], [description], [assessmentId]) VALUES (28, N'State Transition Diagram', 6)
INSERT INTO [dbo].[criteria] ([id], [description], [assessmentId]) VALUES (29, N'User Interface Requirements', 6)
INSERT INTO [dbo].[criteria] ([id], [description], [assessmentId]) VALUES (30, N'Security Requirements and performance requirements', 6)
INSERT INTO [dbo].[criteria] ([id], [description], [assessmentId]) VALUES (31, N'Appendices (Assignment Team Log)', 6)
INSERT INTO [dbo].[criteria] ([id], [description], [assessmentId]) VALUES (32, N'Overall Quality of Report Presentation', 6)
SET IDENTITY_INSERT [dbo].[criteria] OFF

-- Rating Data Insert
SET IDENTITY_INSERT [dbo].[rating] ON
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (1, N'0.25', N'marks', 1)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (2, N'Make necessary and valid process assumptions to', N'Notes & Details', 1)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (3, N'1.5', N'marks', 2)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (4, N'Use correct level of abstraction – one diagram only', N'Notes & Details', 2)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (5, N'1.5', N'marks', 3)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (6, N'Decompose as per rules and use correct BPMN –', N'Notes & Details', 3)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (7, N'5.5', N'marks', 4)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (8, N'Decompose as per rules and use correct BPMN –', N'Notes & Details', 4)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (9, N'0.25', N'marks', 5)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (10, N'Make valid and rational process recommendations', N'Notes & Details', 5)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (11, N'2.75', N'marks', 6)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (12, N'Identify correct and valid entities – at least six', N'Notes & Details', 6)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (13, N'0.75', N'marks', 7)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (14, N'Identify and draw the correct relationship between', N'Notes & Details', 7)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (15, N'0.75', N'marks', 8)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (16, N'Identify and show correct cardinalities between', N'Notes & Details', 8)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (17, N'3', N'marks', 9)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (18, N'Coverage and Correctness:', N'Notes & Details', 9)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (19, N'No Erroes in fully responding to the tasks, and all in-class feedback has been thoroughly implemented', N'60', 10)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (20, N'Satisfactory', N'30', 10)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (21, N'Unsatisfactory', N'0', 10)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (22, N'Successfully addressed all the requirements', N'60', 11)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (23, N'satisfactory', N'30', 11)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (24, N'unsatisfactory', N'0', 11)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (25, N'No errors in fully responding to the tasks, and all in-class feedback has been thoroughly implemented', N'60', 12)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (26, N'Satisfactory', N'30', 12)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (27, N'Unsatisfactory', N'0', 12)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (28, N'Successfully addressed all the requirements', N'60', 13)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (29, N'Satisfactory', N'30', 13)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (30, N'Unsatisfactory', N'0', 13)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (31, N'Context diagram shows more than 3 correctly identified external entities. No errors in using the correct notations. Level 1 diagram shows more than 5 correct main processes (which cover the entire system) and no errors in using the correct notations. Each process on level 1 diagram is very detailed in level 2 with no errors. Extension notations were used correctly through out the diagrams', N'Expert', 14)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (32, N'Context diagram shows 3 correctly identified external entities. No errors in using the correct notations. Level 1 diagram shows 5 correct main processes (which cover the entire system) and no errors in using the correct notations. Each process on level 1 diagram is detailed in level 2 with no errors. Some extension notations were used correctly', N'Proficient', 14)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (33, N'Context diagram shows 3 correctly identified external entities. some errors in using the correct notations. Level 1 diagram shows 5 correct main processes and some errors in using the correct notations. Each process on level 1 diagram is detailed in level 2 with some errors.', N'Emerging', 14)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (34, N'Context diagram did not show correctly identified external entities.errors in using the correct notations. Level 1 diagram shows some main processes and errors in using the correct notations. Some processes on level 1 diagram are detailed in level 2 with errors.', N'Developing', 14)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (35, N'The report report did not provide sufficient details about Context diagram, Level 1 diagram and level 2 diagrams', N'Novice', 14)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (36, N'"ERD showed more than 5 (which cover the entire system) correct and valid entities. Showed correct relationship between entities. Showed correct cardinalities between entities" DD is complete and consistent with ERD', N'Expert', 15)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (37, N'"ERD showed 5 correct and valid entities. Showed correct relationship between entities. Showed correct cardinalities between entities" DD is complete and consistent with ERD', N'Proficient', 15)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (38, N'"ERD showed 5 correct and valid entities. Errors in the relationship between entities. Showed correct cardinalities between entities" DD is incomplete/inconsistent with ERD', N'Emerging', 15)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (39, N'"ERD did not show correct and valid entities. Errors in the relationship between entities. Errors in cardinalities between entities" DD is incomplete/inconsistent with ERD', N'Developing', 15)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (40, N'The report did not provide sufficient details about the ERD and/or Data Dictionary', N'Novice', 15)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (41, N'"Documented more than 2 necessary and valid process assumptions to support the process models and analysis. Made more than 2 valid and necessary data assumptions"', N'Expert', 16)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (42, N'"Documented 2 necessary and valid process assumptions to support the process models and analysis. Made 2 valid and necessary data assumptions"', N'Proficient', 16)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (43, N'" Documented 2 valid process assumptions to support the process models and analysis. Made 2 data assumptions"', N'Emerging', 16)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (44, N'"Documented some process assumptions to support the process models and analysis and some data assumptions"', N'Developing', 16)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (45, N'No assumptions were documented', N'Novice', 16)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (46, N'"Documented more than 2 valid and rational process recommendations for improving the current system and its business processes. Documented more than 2 rational and valid data recommendations for improving the current system that would help the organisation meet its objectives. "', N'Expert', 17)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (47, N'"Documented 2 valid and rational process recommendations for improving the current system and its business processes. Documented 2 rational and valid data recommendations for improving the current system that would help the organisation meet its objectives "', N'Proficient', 17)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (48, N'"Documented valid and rational process recommendations for improving the current system and its business processes. Documented rational and valid data recommendations for improving the current system that would help the organisation meet its objectives "', N'Emerging', 17)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (49, N'"Documented process recommendations for improving the current system and its business processes. Documented data recommendations for improving the current system that would help the organisation meet its objectives "', N'Developing', 17)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (50, N'No recommendations were documented', N'Novice', 17)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (51, N'"Attached completed appendices. Attached signed FEIT declaration of originality assignment cover sheet. Provided student ids and names of all students, and signatures by all students . Included a title page with the project deliverable title. Included table of contents, Used correct spelling, grammar, structure, header, footer, page numbers, consistent font etc. All the diagrams were clear and readable. Included reference list and in-text citations when needed. Used correct APA referencing style, Used the template correctly"', N'Expert', 18)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (52, N'A few components/sections were missing', N'Proficient', 18)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (53, N'Some components were missing', N'Emerging', 18)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (54, N'Many components were missing', N'Developing', 18)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (55, N'Most of the components were missing', N'Novice', 18)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (56, N'Correct templates were used for both the stakeholder table and empathy map. The stakeholder table comprehensively covers the entire system and is concise. The empathy map (s) is thorough and well-detailed, with no flaws in the diagrams', N'Expert', 19)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (57, N'Correct templates were used for both the stakeholder table and empathy map. The stakeholder table comprehensively covers the entire system and is concise. The empathy map (s) is thorough and well-detailed, with a few flaws in the diagrams', N'Proficient', 19)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (58, N'Correct templates were used for both the stakeholder table and empathy map. The stakeholder table comprehensively covers the entire system and is concise. The empathy map (s) is thorough and well-detailed, with some flaws in the diagrams', N'Emerging', 19)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (59, N'Correct templates were used for both the stakeholder table and empathy map (s). The stakeholder table did not comprehensively cover the entire system and is not concise. The empathy map is not thorough , contains several flaws in the diagrams.', N'Developing', 19)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (60, N'Components are missing with several flaws', N'Novice', 19)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (61, N'Provide: Revision History Intended Audience Reference Documents Glossary', N'Expert', 20)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (62, N'A few of the below components are missing: Revision History Intended Audience Reference Documents Glossary', N'Proficient', 20)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (63, N'Some of the below components are missing: Revision History Intended Audience Reference Documents Glossary', N'Emerging', 20)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (64, N'Most of the below components are missing: Revision History Intended Audience Reference Documents Glossary', N'Developing', 20)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (65, N'Entirely Missing', N'Novice', 20)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (66, N'Provide all of the below components: Document Purpose Project Purpose Assumptions', N'Expert', 21)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (67, N'A few of the below components are missing: Document Purpose Project Purpose Assumptions', N'Proficient', 21)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (68, N'Some of the below components are missing: Document Purpose Project Purpose Assumptions', N'Emerging', 21)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (69, N'Many of the below components are missing: Document Purpose Project Purpose Assumptions', N'Developing', 21)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (70, N'Entirely Missing', N'Novice', 21)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (71, N'Provide Use Case Diagram as a Project Boundary Diagram showing all possible use cases. All components of the use case diagram are correct and no flaws in the diagram', N'Expert', 22)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (72, N'Provide Use Case Diagram as a Project Boundary Diagram showing all possible use cases. All components of the use case diagram are correct but there are a few flaws in the diagram', N'Proficient', 22)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (73, N'Provide Use Case Diagram as a Project Boundary Diagram showing all possible use cases. Some components of the use case diagram are incorrect and there are a few flaws in the diagram', N'Emerging', 22)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (74, N'Provide Use Case Diagram as a Project Boundary Diagram showing most of the use cases. Some components of the use case diagram are incorrect and there are a few flaws in the diagram', N'Developing', 22)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (75, N'Provide Use Case Diagram as a Project Boundary Diagram showing limited use cases. Components of the use case diagram are incorrect and there are flaws in the diagram', N'Novice', 22)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (76, N'Identify more than ten possible user stories for the new and improved CCSystem. User stories cover all the features/functionalities of the new improved AA System from a range of users'' perspectives . User stories are testable for completion and they use the correct template. Provide at least one Acceptance Criteria for each user story.', N'Expert', 23)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (77, N'Identify ten possible user stories for the new and improved CC System. User stories cover the features/functionalities of the new improved CC System from a range of users'' perspectives . User stories are testable for completion and they use the correct template. Provide at least one Acceptance Criteria for each user story.', N'Proficient', 23)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (78, N'Identify ten possible user stories for the new and improved CC System. User stories did not cover some of the features/functionalities of the new improved AA System from a range of users'' perspectives . User stories are testable for completion and they use the correct template. Missing Acceptance Criteria for a few user stories.', N'Emerging', 23)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (79, N'Identify ten possible user stories for the new and improved CC System. User stories did not cover some of the features/functionalities of the new improved AA System from a limited users'' perspectives . User stories are testable for completion and they use the correct template. Missing Acceptance Criteria for some user stories.', N'Developing', 23)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (80, N'Identify less than ten possible user stories for the new and improved CC System. User stories did not cover some of the features/functionalities of the new improved AA System from a limited users'' perspectives . User stories are testable for completion and they use the correct template. Missing Acceptance Criteria for some user stories.', N'Novice', 23)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (81, N'Develop a user story map by using the user story map template. ?- List all user stories in this map in correct rows of priority and under correct processes as column headings and provide an id to each. User story map covers the entire online CC system.? All the user stories are Estimated and prioritised . No flaws in the diagram', N'Expert', 24)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (82, N'Develop a user story map by using the user story map template. ?- List all user stories in this map in correct rows of priority and under correct processes as column headings and provide an id to each. User story map covers the entire online CC system.? All the user stories are Estimated and prioritised . A few flaws in the diagram.', N'Proficient', 24)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (83, N'Develop a user story map by using the user story map template. ?- A few errors in listing all your user stories in this map in correct rows of priority and under correct processes as column headings and provide an id to each. User story map does not cover the entire online CC system.? All the user stories are Estimated and prioritised . Some flaws in the diagram.', N'Emerging', 24)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (84, N'Develop a user story map by using the user story map template. ?- Some errors in listing all your user stories in this map in correct rows of priority and under correct processes as column headings and provide an id to each. User story map does not cover the entire online CC system.? All the user stories are not Estimated and prioritised . Some flaws in the diagram.', N'Developing', 24)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (85, N'Did not develop a user story map by using the user story map template. ?many errors in listing all your user stories in this map in correct rows of priority and under correct processes as column headings and provide an id to each. User story map does not cover the entire online CCsystem.? All the user stories are not Estimated and prioritised . Many errors in the diagram.', N'Novice', 24)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (86, N'"Detail more than five user stories by using the use case narrative template', N'Expert', 25)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (87, N' Main Flow follows the format of actor/user actions and system responses. Provide as detailed and descriptive steps as possible in the main flow. Provide Exceptions for all use case narratives. Any Included', N'Proficient', 25)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (88, N' Extended and Inherited use cases', N'Emerging', 25)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (89, N' are narrated separately in a separate use case.?- Every alternate flow provided (if any) are detailed in the “Alternate Flow” section. Not all your use cases may have an Alternate Flow."', N'Developing', 25)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (90, N'"Detail five user stories by using the use case narrative template', N'Novice', 25)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (91, N'Document more than two Sequence Diagrams . ?all diagrams are drawn at an Object-level showing all the objects (participants) interacting within that use case (and within the CC system) instead of just showing one object for the entire system such as CCS object. ? - Provide clear title for each sequence diagram and the name of the corresponding use case. - Messages in the sequence diagram match with the main flow of the corresponding use case narrative. These messages are in a logical sequence and cover the narrative from the start to the end. Messages start with a verb and sound like a method.?- - Any Alternate flows narrated in your use case narrative shown either in the same/original sequence diagram (preferred method) using an Alt frame or shown in a separate sequence diagram. No errors in any of the above mentioned sections/components of the diagrams', N'Expert', 26)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (92, N'Document two Sequence Diagrams . ?Both diagrams are drawn at an Object-level showing all the objects (participants) interacting within that use case (and within the CC system) instead of just showing one object for the entire system such as CCS object. ? - Provide clear title for each sequence diagram and the name of the corresponding use case. - Messages in the sequence diagram match with the main flow of the corresponding use case narrative. These messages are in a logical sequence and cover the narrative from the start to the end. Messages start with a verb and sound like a method.?- - Any Alternate flows narrated in your use case narrative shown either in the same/original sequence diagram (preferred method) using an Alt frame or shown in a separate sequence diagram. A few errors in any of the above mentioned sections/components of the diagrams', N'Proficient', 26)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (93, N'Document two Sequence Diagrams . ?Both diagrams are drawn at an Object-level showing all the objects (participants) interacting within that use case (and within the CC system) instead of just showing one object for the entire system such as CCS object. ? - Provide clear title for each sequence diagram and the name of the corresponding use case. - Messages in the sequence diagram match with the main flow of the corresponding use case narrative. These messages are in a logical sequence and cover the narrative from the start to the end. Messages start with a verb and sound like a method.?- - Any Alternate flows narrated in your use case narrative shown either in the same/original sequence diagram (preferred method) using an Alt frame or shown in a separate sequence diagram. Some errors in any of the above mentioned sections/components of the diagrams', N'Emerging', 26)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (94, N'Document two Sequence Diagrams . ?Both diagrams are drawn at an Object-level showing all the objects (participants) interacting within that use case (and within the CCsystem) instead of just showing one object for the entire system such as CCS object. ? - Provide clear title for each sequence diagram and the name of the corresponding use case. - Messages in the sequence diagram match with the main flow of the corresponding use case narrative. These messages are in a logical sequence and cover the narrative from the start to the end. Messages start with a verb and sound like a method.?- - Any Alternate flows narrated in your use case narrative shown either in the same/original sequence diagram (preferred method) using an Alt frame or shown in a separate sequence diagram. More errors in any of the above mentioned sections/components of the diagram', N'Developing', 26)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (95, N'Document two Sequence Diagrams . ?Both diagrams are drawn at an Object-level showing all the objects (participants) interacting within that use case (and within the CC system) instead of just showing one object for the entire system such as CCS object. ? - Provide clear title for each sequence diagram and the name of the corresponding use case. - Messages in the sequence diagram match with the main flow of the corresponding use case narrative. These messages are in a logical sequence and cover the narrative from the start to the end. Messages start with a verb and sound like a method.?- - Any Alternate flows narrated in your use case narrative shown either in the same/original sequence diagram (preferred method) using an Alt frame or shown in a separate sequence diagram. A number of above mentioned components were missing and/or incorrectly documented', N'Novice', 26)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (96, N'Document one Class Diagram that covers the entire improved CC System. ?- Identify more than five appropriate classes.? The class diagram covers the entire system ?- Identify the correct relationship between these classes and define the multiplicities. - Identify all the important and necessary attributes for each class in your class diagram. Provide data types for each attribute.?- Identify all the important and necessary methods for each class in your class diagram. No errors in any of the above components of the class diagram', N'Expert', 27)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (97, N'Document one Class Diagram that covers the entire improved CC System. ?- Identify five appropriate classes.? The class diagram covers the entire system. ?- Identify the correct relationship between these classes and define the multiplicities. - Identify all the important and necessary attributes for each class in your class diagram. Provide data types for each attribute.?- Identify all the important and necessary methods for each class in your class diagram. No errors in any of the above components of the class diagram', N'Proficient', 27)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (98, N'Document one Class Diagram that covers the entire improved CC System. ?- Identify five appropriate classes.? The class diagram covers the entire system . ?- Identify the correct relationship between these classes and define the multiplicities. - Identify all the important and necessary attributes for each class in your class diagram. Provide data types for each attribute.?- Identify all the important and necessary methods for each class in class diagram. A few errors in any of the above components of the class diagram', N'Emerging', 27)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (99, N'Document one Class Diagram that covers the entire improved CCSystem. ?- Identify five appropriate classes.? The class diagram covers the entire system. ?- Identify the correct relationship between these classes and define the multiplicities. - Identify all the important and necessary attributes for each class in your class diagram. Provide data types for each attribute.?- Identify all the important and necessary methods for each class in class diagram. Some errors in any of the above components of the class diagram', N'Developing', 27)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (100, N'Document one Class Diagram that covers the entire improved CC System. ?- Identify less than five appropriate classes.? The class diagram does not cover the entire system . ?- Identify the correct relationship between these classes and define the multiplicities. - Identify all the important and necessary attributes for each class in your class diagram. Provide data types for each attribute.?- Identify all the important and necessary methods for each class in class diagram. Many errors in any of the above components of the class diagram', N'Novice', 27)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (101, N'"Draw one State Transition Diagram for the “Customer/passenger” object that covers all user stories and use case narratives that the Customer participates in (across the entire CC system).?- State transition diagram shows the initial and final states.?- Identify more than five correct states of the Customer object. - Identify', N'Expert', 28)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (102, N' label and correctly name the Events/Triggers. No errors in any of the sections mentioned above"', N'Proficient', 28)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (103, N'"Draw one State Transition Diagram for the “Customer/passenger” object that covers all user stories and use case narratives that the Customer participates in (across the entire CC system).?- State transition diagram shows the initial and final states.?- Identify at least five correct states of the Customer object. - Identify', N'Emerging', 28)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (104, N' label and correctly name the Events/Triggers. No errors in any of the sections mentioned above"', N'Developing', 28)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (105, N'"Draw one State Transition Diagram for the “Customer/passenger” object that covers all user stories and use case narratives that the Customer participates in (across the entire CC system).?- State transition diagram shows the initial and final states.?- Identify at least five correct states of the Customer object. - Identify', N'Novice', 28)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (106, N'"Document two sets of user interfaces or wireframes for any two use cases of your choice', N'Expert', 29)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (107, N' should be the same as the ones you choose for the sequence diagrams -Draw many screens for each wireframe/use case.? Provide the title for each wireframe and a clear name for the corresponding use case and/or user story. No errors in the diagrams."', N'Proficient', 29)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (108, N'"Document two sets of user interfaces or wireframes for any two use cases of your choice', N'Emerging', 29)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (109, N' should be the same as the ones you choose for the sequence diagrams -Draw many screens for each wireframe/use case.? Provide the title for each wireframe and a clear name for the corresponding use case and/or user story. A few errors in the diagrams."', N'Developing', 29)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (110, N'"Document two sets of user interfaces or wireframes for any two use cases of your choice', N'Novice', 29)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (111, N'"Document more than two valid security requirements for the system. ????Requirement statements must satisfy the “SMART” requirements quality criteria. Document more than two valid performance requirements for the system', N'Expert', 30)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (112, N' No errors Requirement statements must satisfy the “SMART” requirements quality criteria."', N'Proficient', 30)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (113, N'"Document two valid security requirements for the system. ????Requirement statements must satisfy the “SMART” requirements quality criteria. Document n two valid performance requirements for the system', N'Emerging', 30)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (114, N' Requirement statements must satisfy the “SMART” requirements quality criteria. No errors"', N'Developing', 30)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (115, N'"Document two valid security requirements for the system. ????Requirement statements must satisfy the “SMART” requirements quality criteria. Document n two valid performance requirements for the system', N'Novice', 30)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (116, N'"Contribution to Teamwork (Evidence): submit the contribution of each team member to each task. The contribution should be shown via the Contributions Table. detailed record of team communication (e.g. emails', N'Expert', 31)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (117, N' proof of group meetings', N'Proficient', 31)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (118, N' meeting minutes', N'Emerging', 31)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (119, N' screenshots of online conversations', N'Developing', 31)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (120, N' etc.) Very detailed team log is provided"', N'Novice', 31)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (121, N'"Include a separate title page with the project deliverable title and table of contents. Use correct spelling', N'Expert', 32)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (122, N' grammar', N'Proficient', 32)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (123, N' structure', N'Emerging', 32)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (124, N' clarity', N'Developing', 32)
INSERT INTO [dbo].[rating] ([id], [description], [grade], [criteriaId]) VALUES (125, N' header', N'Novice', 32)
SET IDENTITY_INSERT [dbo].[rating] OFF

-- Year Association Data Insert
SET IDENTITY_INSERT [dbo].[yearAssociation] ON
INSERT INTO [dbo].[yearAssociation] ([id], [name], [isStudent], [studentId], [tutorId]) VALUES (1, 2020, 1, 13888767, NULL)
INSERT INTO [dbo].[yearAssociation] ([id], [name], [isStudent], [studentId], [tutorId]) VALUES (4, 2020, 0, NULL, 97492185)
INSERT INTO [dbo].[yearAssociation] ([id], [name], [isStudent], [studentId], [tutorId]) VALUES (1002, 2020, 1, 11111111, NULL)
SET IDENTITY_INSERT [dbo].[yearAssociation] OFF

-- Semester Association Data Insert
SET IDENTITY_INSERT [dbo].[semesterAssociation] ON
INSERT INTO [dbo].[semesterAssociation] ([id], [name], [isStudent], [yearId], [semesterId], [studentId], [tutorId]) VALUES (1, N'Autumn', 1, 1, 1, 13888767, NULL)
INSERT INTO [dbo].[semesterAssociation] ([id], [name], [isStudent], [yearId], [semesterId], [studentId], [tutorId]) VALUES (3, N'Autumn', 0, 4, 1, NULL, 97492185)
INSERT INTO [dbo].[semesterAssociation] ([id], [name], [isStudent], [yearId], [semesterId], [studentId], [tutorId]) VALUES (1002, N'Autumn', 1, 1002, 1, 11111111, NULL)
SET IDENTITY_INSERT [dbo].[semesterAssociation] OFF

-- Course Association Data Insert
SET IDENTITY_INSERT [dbo].[courseAssociation] ON
INSERT INTO [dbo].[courseAssociation] ([id], [isStudent], [isCompleted], [courseId], [semesterId], [studentId], [tutorId]) VALUES (13, 1, 0, 1, 1, 13888767, NULL)
INSERT INTO [dbo].[courseAssociation] ([id], [isStudent], [isCompleted], [courseId], [semesterId], [studentId], [tutorId]) VALUES (17, 0, 0, 1, 3, NULL, 97492185)
INSERT INTO [dbo].[courseAssociation] ([id], [isStudent], [isCompleted], [courseId], [semesterId], [studentId], [tutorId]) VALUES (18, 1, 0, 1, 1002, 11111111, NULL)
SET IDENTITY_INSERT [dbo].[courseAssociation] OFF

-- Student Course Data Insert
SET IDENTITY_INSERT [dbo].[studentCourse] ON
INSERT INTO [dbo].[studentCourse] ([id], [courseAssociationId], [courseMark], [tutorialId], [userId]) VALUES (12, 13, CAST(95.00 AS Decimal(18, 2)), 1, 13888767)
INSERT INTO [dbo].[studentCourse] ([id], [courseAssociationId], [courseMark], [tutorialId], [userId]) VALUES (13, 18, CAST(0.00 AS Decimal(18, 2)), 1, 11111111)
SET IDENTITY_INSERT [dbo].[studentCourse] OFF

-- Tutor Course Data Insert
SET IDENTITY_INSERT [dbo].[tutorCourse] ON
INSERT INTO [dbo].[tutorCourse] ([id], [courseAssociationId], [tutorialId], [userId]) VALUES (1, 17, N'1,', 97492185)
SET IDENTITY_INSERT [dbo].[tutorCourse] OFF

-- Student Assessment Data Insert
SET IDENTITY_INSERT [dbo].[studentAssessment] ON
INSERT INTO [dbo].[studentAssessment] ([id], [assessmentId], [status], [studentMark], [isFinalised], [feedback], [courseId], [userId]) VALUES (3, 1, 0, CAST(19.00 AS Decimal(18, 2)), 1, N'Summary of Student''s Progress:
The student has demonstrated significant improvements in their understanding of Business Process Modeling and Entity Relationship Diagrams, as evident from their high score of 19 out of 20 in Assignment Task 1. They have shown commendable attention to detail, thorough analysis, and a strong grasp of the concepts taught in the subject.

Areas of Improvement:
1. **Assumptions Alignment**: While the student''s work is commendable, they need to ensure that their assumptions align closely with the information provided in the case study to avoid contradictions.
2. **Decision Gateways Labeling**: The student should work on labeling decision gateways with both options clearly and ensuring they do not replace actual processes.
3. **Process Clarity**: Clear definition of missing processes, particularly those transformed into decision gateways, would enhance the overall quality of the analysis.
4. **Entity-Relationship Refinements**: Improving the readability and logical coherence of relationships in Entity Relationship Diagrams is essential for better understanding.
5. **Data Model Enhancements**: Revising relationships and cardinalities to strengthen the overall data model is recommended for a more robust analysis.
6. **Recommendations Clarity**: Providing clear and rational process recommendations would further enhance the student''s analysis and insights.

Suggestions for Further Improvement:
1. Engage closely with the case study and ensure all assumptions are in line with the provided information.
2. Practice labeling decision gateways clearly and distinguishing them from actual processes.
3. Focus on clarifying missing processes and refining entity-relationship diagrams for better readability and logical consistency.
4. Review data model relationships and cardinalities to ensure they accurately represent the underlying business processes.
5. Work on providing clear and actionable recommendations based on the analyzed processes.

Overall, the student has shown remarkable progress, and with continued focus on refining their assumptions, decision gateways, and relationships, they are poised to excel further in Business Process Modeling and Entity Relationship Diagrams. Through implementing the actionable suggestions provided, the student can continue to enhance their understanding and application of the subject matter. Keep up the excellent work!', 13, 13888767)
INSERT INTO [dbo].[studentAssessment] ([id], [assessmentId], [status], [studentMark], [isFinalised], [feedback], [courseId], [userId]) VALUES (4, 2, 0, CAST(0.00 AS Decimal(18, 2)), 0, N'', 13, 13888767)
INSERT INTO [dbo].[studentAssessment] ([id], [assessmentId], [status], [studentMark], [isFinalised], [feedback], [courseId], [userId]) VALUES (5, 1, 0, CAST(0.00 AS Decimal(18, 2)), 0, N'', 18, 11111111)
INSERT INTO [dbo].[studentAssessment] ([id], [assessmentId], [status], [studentMark], [isFinalised], [feedback], [courseId], [userId]) VALUES (6, 2, 0, CAST(0.00 AS Decimal(18, 2)), 0, N'', 18, 11111111)
SET IDENTITY_INSERT [dbo].[studentAssessment] OFF

-- CheckList Data Insert
SET IDENTITY_INSERT [dbo].[checkList] ON
INSERT INTO [dbo].[checkList] ([id], [name], [isChecked], [assessmentId], [userId]) VALUES (1, N'create diagram', 1, 3, 13888767)
INSERT INTO [dbo].[checkList] ([id], [name], [isChecked], [assessmentId], [userId]) VALUES (2, N'create report', 1, 3, 13888767)
INSERT INTO [dbo].[checkList] ([id], [name], [isChecked], [assessmentId], [userId]) VALUES (3, N'get feedback', 1, 3, 13888767)
INSERT INTO [dbo].[checkList] ([id], [name], [isChecked], [assessmentId], [userId]) VALUES (4, N'submit assessment', 1, 3, 13888767)
SET IDENTITY_INSERT [dbo].[checkList] OFF

-- Feedeback Result Data Insert
SET IDENTITY_INSERT [dbo].[feedbackResult] ON
INSERT INTO [dbo].[feedbackResult] ([id], [attempt], [teacherFeedback], [fileName], [fileData], [notes], [feedback], [previousAttemptId], [previousAssessmentId], [assessmentId], [userId])
VALUES (1,
        1,
        N'I noticed that some of your assumptions contradict the information provided in the case study, particularly regarding the involvement of the third-party verification provider. It’s important to ensure your assumptions align with the facts given. Additionally, your decision gateways could use improvement. Many of them only indicate one option, which doesn’t provide a clear decision path. Please make sure both options are represented, and remember that gateways should not replace key processes. Some processes, such as ''provide required contact details,'' should be standalone steps rather than being converted into decision points. There are also a few missing processes, which might have been unintentionally turned into decision gateways. Ensure that each process is clearly defined and includes appropriate start and end events. Lastly, while your entity relationships are mostly strong, some could be improved for clarity. For instance, ‘agreement contract receives terms and service’ doesn’t quite make sense as written, and relationships like ‘staff retrieve identification’ could be simplified for readability. Overall, you’ve done excellent work, but refining these areas will further enhance the quality of your submission',
         N'Assignment Task 1 Requirement Analysis_ Wrk 01 Group 1.pdf', 0x41737369676E6D656E74205461736B203120526571756972656D656E740A416E616C797369733A2057726B2030312047726F757020310A62207920596572616E20486574746961726163686368790A5375626D697373696F6E20646174653A2032372D4170722D323032302031303A3132504D20285554432B31303030290A53, N'Please review the assumptions I’ve made and check if they align with the case study details, especially regarding third-party involvement. I’m concerned that some might not be fully accurate. Additionally, could you examine my decision gateways to ensure they provide clear options for both outcomes? I’d like feedback on whether any processes have been turned into decision gateways by mistake, as I’m not sure if I’ve missed defining certain processes properly. When it comes to the entity relationships, please highlight any that don’t make sense when read aloud or seem overly complex. I want to ensure the relationships are logical and easy to follow. Finally, I would appreciate any guidance on improving the clarity and structure of my work overall. Thanks for helping me refine these areas.',
                                                                                        N'Grade: 19/20

Feedback:
Congratulations on receiving a high score of 19 out of 20 on your Requirement Analysis report for Assignment Task 1. You have demonstrated an excellent understanding of Business Process Modelling and Entity Relationship Diagrams. Your work reflects attention to detail and thorough analysis of the case study provided. Your efforts are commendable, and you are on the right track towards mastering the concepts taught in this subject.

Next Steps:
1. **Address Assumptions**: Ensure that your assumptions align with the information presented in the case study to avoid contradictions (Comment 1).
2. **Improve Decision Gateways**: Label decision gateways with both options and ensure they do not replace actual processes (Comment 2).
3. **Process Clarity**: Clearly define missing processes, particularly those that have been turned into decision gateways (Comment 4).
4. **Entity-Relationship Refinements**: Enhance your relationships by improving readability and ensuring they make logical sense when read aloud (Comment 9).
5. **Data Model Enhancements**: Consider revising the relationships and cardinalities to strengthen the overall data model (Rubric, 2.3, 2.4).
6. **Recommendations**: Provide clear and rational process recommendations (Rubric, 1.5).

Criterion:
- **Context Diagram (Rating: HD)**: You effectively used the correct level of abstraction.
- **Level 2 Diagrams (Rating: HD)**: Your decomposition adhered to the rules and used the correct BPMN.
- **Entities (Rating: HD)**: Identified correct entities; aim to ensure relationships align logically.
- **Data Dictionary (Rating: HD)**: Achieved coverage and correctness in detailing the data model.

Keep up the excellent work! If you focus on refining your assumptions, decision gateways, and relationships in your future submissions, you will undoubtedly continue to excel in this subject. Utilize the feedback provided to enhance your understanding and application of Business Process Modelling and Entity Relationship Diagrams further. Great job!',
                                                                                         NULL,
                                                                                         NULL,
                                                                                         3,
                                                                                         13888767)
INSERT INTO [dbo].[feedbackResult] ([id], [attempt], [teacherFeedback], [fileName], [fileData], [notes], [feedback], [previousAttemptId], [previousAssessmentId], [assessmentId], [userId])
VALUES (2,
        1,
        N'remember to follow the template for the user story map',
         N'Tutorial 6.pdf', 0x466163756C7479206F6620456E67696E656572696E6720616E64204954200A5363686F6F6C206F6620436F6D707574657220536369656E6365200A333132363920427573696E65737320526571756972656D656E7473204D6F64656C6C696E6720200A5765656B20373A204167696C6520446576656C6F706D656E7420776974, N'',
                                            N'Grade: 75/100

Feedback:
- Your group has shown a good understanding of agile software requirement specification and user stories. You have successfully developed user stories and acceptance criteria for the ''Bookish Bliss'' case study based on the existing business processes.
- Your submission overall is satisfactory in meeting the requirements of the assessment tasks.

Next Steps:
1. **Attention to Detail**: Pay close attention to the details and requirements outlined in the tasks. Ensure that all aspects, such as additional user stories and acceptance criteria, are fully addressed for a more comprehensive submission.
2. **Template Adherence**: Follow the user story map template provided in the instructions. Ensuring consistency and adherence to the given guidelines can enhance the clarity and structure of your work.
3. **Proofreading**: Prior to submission, thoroughly proofread your work to eliminate any errors or inconsistencies that may impact the clarity and professionalism of your submission.

Criterion:
- Correctness: Satisfactory
- Completeness: Satisfactory',
                                             NULL,
                                             NULL,
                                             4,
                                             13888767)
INSERT INTO [dbo].[feedbackResult] ([id], [attempt], [teacherFeedback], [fileName], [fileData], [notes], [feedback], [previousAttemptId], [previousAssessmentId], [assessmentId], [userId])
VALUES (3,
        2,
        N'Remember to use a rule-based approach for acceptance criteria. ',
         N'Tutorial 6 sample for testing.pdf', 0x200A5461736B203120E28093557365722053746F72696573200A20200A312E20426F6F6B20526563656976696E672050726F63657373200AE2978F204173206120726563656976696E6720636C65726B2C20492077616E7420746F2072656365697665206175746F6D61746564206E6F74696669636174696F6E73207768656E, N'',
                                                               N'Grade: 80/100

Feedback:
Overall, your user stories and acceptance criteria demonstrate a good understanding of the agile software requirement specification approach. Your user stories are clear and detailed, addressing various user perspectives and system functionalities effectively. The acceptance criteria are well-defined, ensuring the precise implementation and testing of each user story. Your estimation with Fibonacci series and prioritization using MoSCoW method are appropriately done, showcasing your ability to estimate and prioritize user stories effectively.

Next Steps:
1. When developing user stories, ensure to capture all essential details from the user''s perspective, system functionalities, and acceptance criteria to provide a comprehensive understanding for implementation.
2. Pay attention to the rule-based approach for acceptance criteria, ensuring that each criterion is specific, measurable, achievable, relevant, and time-bound.
3. Improve the clarity and specificity of user story estimates and prioritization by providing more detailed explanations for each story''s complexity and importance.

Criterion: Completeness (Satisfactory)
- You have successfully addressed all the requirements of the tasks, including developing user stories, acceptance criteria, estimation, and prioritization. Your user story map demonstrates the prioritization of features based on their importance and complexity.

For further enhancement:
- Provide additional details or examples to support the reasoning behind the prioritization of user stories.
- Consider incorporating feedback or suggestions from stakeholders to refine the prioritization process and ensure alignment with business goals.

Keep up the good work and continue refining your agile software requirement specification approach to enhance the quality and effectiveness of your user stories and acceptance criteria.',
                                                                NULL,
                                                                NULL,
                                                                4,
                                                                13888767)
SET IDENTITY_INSERT [dbo].[feedbackResult] OFF

-- Event Data Insert
SET IDENTITY_INSERT [dbo].[event] ON
INSERT INTO [dbo].[event] ([id], [name], [date], [startTime], [endTime], [category], [color], [courseId], [userId]) VALUES (1, N'Tutorial', N'2024-09-26 10:29:49', N'13:00:00', N'15:00:00', N'Business Requirements Modelling', -16711872, 13, 13888767)
INSERT INTO [dbo].[event] ([id], [name], [date], [startTime], [endTime], [category], [color], [courseId], [userId]) VALUES (2, N'Tutorial Class', N'2024-09-27 12:20:54', N'13:00:00', N'15:00:00', N'Business Requirements Modelling', -16760704, 13, 13888767)
INSERT INTO [dbo].[event] ([id], [name], [date], [startTime], [endTime], [category], [color], [courseId], [userId]) VALUES (3, N'A1 Due', N'2024-10-04 12:21:14', N'12:21:14.0965243', N'12:21:14.0925145', N'Business Requirements Modelling', -16116185, 13, 13888767)
INSERT INTO [dbo].[event] ([id], [name], [date], [startTime], [endTime], [category], [color], [courseId], [userId]) VALUES (6, N'Tutorial  1', N'2024-10-05 17:08:38', N'13:00:00', N'15:00:00', N'Business Requirements Modelling', -128, 17, 97492185)
SET IDENTITY_INSERT [dbo].[event] OFF

