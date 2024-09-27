function GetStudents() {
    $.ajax({
        url: "https://localhost:7156/Challenge/api/Students",
        type: "GET",
        success: function (data) {
            console.log("Got a response from server");
            if (data.ok) {
                $("#loadingContentDiv").addClass("hidden-div");
                $("#studentsTableDiv").removeClass("hidden-div");
                LoadStudentsTable(data);
            }
            else {

            }
            // Handle the successful response data here
            console.log(data);
        },
        error: function (xhr, status, error) {
            // Handle the error response here
            console.error("Error:", error);
        }
    });
}

function LoadStudentsTable(data) {
    const students = data.students; // Assuming data.students is the array
    const tbody = $('#studentsTable tbody');

    // Clear existing rows
    tbody.empty();
    // Loop through the students and append rows to the table
    students.forEach(function (student) {
        const row = `
            <tr>
                <td>${student.studentId}</td>
                <td>${student.firstName}</td>
                <td>${student.lastName}</td>
                <td>
                    <button class="custom-button" data-id="${student.studentId}">Details</button>
                </td>
            </tr>
        `;
        tbody.append(row);
    });
}

function GetStudentById(id) {
    $.ajax({
        url: `https://localhost:7156/Challenge/api/Students/${id}`,
        type: "GET",
        success: function (data) {
            console.log("Got a response from server");
            if (data.ok) {
                // Handle the successful response data here
                console.log(data);
                $("#loadingContentDiv").addClass("hidden-div");
                $("#studentDetailsDiv").removeClass("hidden-div");
                LoadStudentDetails(data);
            }
            else {

            }

        },
        error: function (xhr, status, error) {
            // Handle the error response here
            console.error("Error:", error);
        }
    });
}

function LoadStudentDetails(data) {
    const student = data.students[0];

    $('#studentId').text(student.studentId);
    $('#firstName').text(student.firstName);
    $('#lastName').text(student.lastName);

    student.examScores.forEach(function (exam) {
        // Extract just the date part (YYYY-MM-DD)
        const dateOnly = exam.dateTaken.split('T')[0];

        const card = `
        <div class="exam-card">
            <h3>${exam.examName}</h3>
            <p><strong>Exam ID:</strong> ${exam.examId}</p>
            <p>
                <label for="dateTaken-${exam.examId}">Date Taken:</label>
                <input type="date" id="dateTaken-${exam.examId}" value="${dateOnly}" />
            </p>
            <p>
                <label for="score-${exam.examId}">Score:</label>
                <input type="number" id="score-${exam.examId}" value="${exam.score}" />
            </p>
            <p>
                <label for="isPassed-${exam.examId}">Passed:</label>
                <select id="isPassed-${exam.examId}">
                    <option value="null" ${exam.isPassed === null || exam.isPassed === undefined ? 'selected' : ''}>Null</option>   
                    <option value="true" ${exam.isPassed ? 'selected' : ''}>Yes</option>
                    <option value="false" ${exam.isPassed === false ? 'selected' : ''}>No</option>
                </select>
            </p>
            <button class="custom-button update-btn" data-id="${exam.examId}">Update</button>
        </div>
    `;
        $('#examList').append(card);
    });
}

function UpdateExam(studentId, examId, dateTaken, score, isPassed) {
    const examData = {
        studentId: parseInt(studentId, 10),
        examId: parseInt(examId, 10),
        dateTaken: dateTaken,
        score: parseInt(score, 10),
        isPassed: isPassed
    };

    $.ajax({
        url: `https://localhost:7156/Challenge/api/Exam`,
        type: 'PUT',
        contentType: 'application/json',
        data: JSON.stringify(examData),
        success: function (response) {
            console.log('Exam updated successfully:', response);
            alert('Exam updated successfully!');
        },
        error: function (xhr, status, error) {
            console.error('Error updating exam:', error);
            alert('Failed to update exam. Please try again.');
        }
    });
}

