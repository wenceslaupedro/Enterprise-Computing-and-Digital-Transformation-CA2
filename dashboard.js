document.addEventListener('DOMContentLoaded', () => {
    //calendar
    let currentDate = new Date();
    updateCalendar(currentDate);

    //month navigation
    document.getElementById('prevMonth').addEventListener('click', () => {
        currentDate.setMonth(currentDate.getMonth() - 1);
        updateCalendar(currentDate);
    });

    document.getElementById('nextMonth').addEventListener('click', () => {
        currentDate.setMonth(currentDate.getMonth() + 1);
        updateCalendar(currentDate);
    });

    //submission form
    const workoutForm = document.getElementById('addWorkoutForm');
    if (workoutForm) {
        workoutForm.addEventListener('submit', async (e) => {
            e.preventDefault();
            const workoutData = {
                type: document.getElementById('workoutType').value,
                duration: parseInt(document.getElementById('workoutDuration').value),
                calories: parseInt(document.getElementById('workoutCalories').value),
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
                    const errorData = await response.json();
                    alert(errorData.message || 'Failed to add workout. Please try again.');
                }
            } catch (error) {
                console.error('Error adding workout:', error);
                alert('An error occurred while adding the workout. Please try again.');
            }
        });
    }
});

async function updateCalendar(date) {
    const calendar = document.getElementById('calendar');
    const monthDisplay = document.getElementById('currentMonth');
    
    //month update
    monthDisplay.textContent = date.toLocaleString('default', { month: 'long', year: 'numeric' });
    
    //calendar clear
    calendar.innerHTML = '';
    
    //first day of month and total days
    const firstDay = new Date(date.getFullYear(), date.getMonth(), 1);
    const lastDay = new Date(date.getFullYear(), date.getMonth() + 1, 0);
    
    //days before first day of month
    for (let i = 0; i < firstDay.getDay(); i++) {
        calendar.appendChild(createDayElement(''));
    }
    
    //add days of the month
    for (let day = 1; day <= lastDay.getDate(); day++) {
        const dayElement = createDayElement(day);
        const currentDate = new Date(date.getFullYear(), date.getMonth(), day);
        
        //add click handler for date selection
        dayElement.addEventListener('click', () => {
            document.getElementById('workoutDate').value = currentDate.toISOString().split('T')[0];
        });
        
        //what workouts for this day
        try {
            const response = await fetch(`/api/workouts?date=${currentDate.toISOString().split('T')[0]}`, {
                headers: {
                    'Authorization': `Bearer ${localStorage.getItem('authToken')}`
                }
            });
            
            if (response.ok) {
                const workouts = await response.json();
                if (workouts.length > 0) {
                    dayElement.classList.add('has-workouts');
                    const workoutCount = document.createElement('div');
                    workoutCount.className = 'workout-count';
                    workoutCount.textContent = `${workouts.length} workout${workouts.length > 1 ? 's' : ''}`;
                    dayElement.appendChild(workoutCount);
                }
            }
        } catch (error) {
            console.error('Error fetching workouts:', error);
        }
        
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