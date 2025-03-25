document.addEventListener('DOMContentLoaded', () => {
    // Initialize calendar
    let currentDate = new Date();
    updateCalendar(currentDate);

    // Month navigation
    document.getElementById('prevMonth').addEventListener('click', () => {
        currentDate.setMonth(currentDate.getMonth() - 1);
        updateCalendar(currentDate);
    });

    document.getElementById('nextMonth').addEventListener('click', () => {
        currentDate.setMonth(currentDate.getMonth() + 1);
        updateCalendar(currentDate);
    });

    // Workout form submission
    const workoutForm = document.getElementById('addWorkoutForm');
    if (workoutForm) {
        workoutForm.addEventListener('submit', async (e) => {
            e.preventDefault();
            const workoutData = {
                type: document.getElementById('workoutType').value,
                duration: document.getElementById('workoutDuration').value,
                calories: document.getElementById('workoutCalories').value,
                date: document.getElementById('workoutDate').value
            };

            try {
                const response = await fetch('/api/workouts', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                        'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                    },
                    body: JSON.stringify(workoutData)
                });

                if (response.ok) {
                    workoutForm.reset();
                    updateCalendar(currentDate); // Refresh calendar
                } else {
                    alert('Failed to add workout. Please try again.');
                }
            } catch (error) {
                console.error('Error adding workout:', error);
            }
        });
    }
});

function updateCalendar(date) {
    const calendar = document.getElementById('calendar');
    const monthDisplay = document.getElementById('currentMonth');
    
    // Update month display
    monthDisplay.textContent = date.toLocaleString('default', { month: 'long', year: 'numeric' });
    
    // Clear calendar
    calendar.innerHTML = '';
    
    // Get first day of month and total days
    const firstDay = new Date(date.getFullYear(), date.getMonth(), 1);
    const lastDay = new Date(date.getFullYear(), date.getMonth() + 1, 0);
    
    // Add empty cells for days before first day of month
    for (let i = 0; i < firstDay.getDay(); i++) {
        calendar.appendChild(createDayElement(''));
    }
    
    // Add days of the month
    for (let day = 1; day <= lastDay.getDate(); day++) {
        const dayElement = createDayElement(day);
        dayElement.addEventListener('click', () => {
            document.getElementById('workoutDate').value = `${date.getFullYear()}-${String(date.getMonth() + 1).padStart(2, '0')}-${String(day).padStart(2, '0')}`;
        });
        calendar.appendChild(dayElement);
    }
}

function createDayElement(day) {
    const div = document.createElement('div');
    div.className = 'calendar-day';
    div.textContent = day;
    
    if (day) {
        div.classList.add('has-content');
    }
    
    return div;
} 