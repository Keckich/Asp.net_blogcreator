﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

AjaxDeleteComment = form => {
    
    if (confirm('Are you sure to delete this object? It cannot be restored.')) {
        try {
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    $("#details").html(res.html);
                }            

            })
            console.log(form.postId);
        } catch (e) {
            console.log(e);
        }
    }
    return false;
}


AjaxDelete = form => {
    if (confirm('Are you sure to delete this object? It cannot be restored.')) {
        try {
            $.ajax({
                type: 'POST',
                url: form.actinon,
                data: new FormData(form),
                contentType: false,
                processData: false,
                    success: function (res) {
                        $("#details").html(res.html);
                        
                    }

        })
        
    } catch (e) {
        console.log(e);
    }
}
return false;
}