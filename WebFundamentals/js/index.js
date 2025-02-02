function sayHi(){
    document.getElementById('myP').innerHTML = 'Hi, I am changed.';
}
var Vehicle = function (make, model, year) {
    this.make = make;
    this.model = model;
    this.year = year;
};
Vehicle.prototype.start = function () {
    console.log('Starting...');
};
Vehicle.prototype.toString = function () {
    return this.make + ' ' + this.model + ' (' + this.year + ')';
};
var vehicle = new Vehicle('Toyota', 'Camry', 2017);
vehicle.start();
console.log(vehicle);