function triggerFileUpload() {
    document.getElementById('profileImageUpload').click();
}

function previewAndSubmit() {
    const fileInput = document.getElementById('profileImageUpload');
    const file = fileInput.files[0];
    const reader = new FileReader();

    if (file) {
        // Preview the image
        reader.onload = function (e) {
            document.getElementById('profileImage').src = e.target.result;
        };
        reader.readAsDataURL(file);

        // Submit the image (send to the server)
        uploadProfilePicture(file);
    }
}

function uploadProfilePicture(file) {
    const formData = new FormData();
    formData.append('profileImage', file);

    fetch('/User/UploadProfilePicture', {
        method: 'POST',
        body: formData
    })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                alert('Profile picture updated successfully!');
            } else {
                alert('Failed to update profile picture. Please try again.');
            }
        })
        .catch(error => {
            console.error('Error uploading profile picture:', error);
        });
}
