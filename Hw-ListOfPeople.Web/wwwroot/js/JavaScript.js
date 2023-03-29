$(() => {
    let newrow = 1;
    $("#add-rows").on('click', function () {
        $("#ppl-row").append(`<div class="row person-row" style="margin-bottom: 10px;">
            <div class="col-md-4">
                <input class="form-control" type="text" name="people[${newrow}].firstname" placeholder="First Name" />
            </div>
            <div class="col-md-4">
                <input class="form-control" type="text" name="people[${newrow}].lastname" placeholder="Last Name" />
            </div>
            <div class="col-md-4">
                <input class="form-control" type="text" name="people[${newrow}].age" placeholder="Age" />
            </div>
        </div>`)
        newrow++;
    });
})