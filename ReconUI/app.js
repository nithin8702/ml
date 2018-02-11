const express = require('express')
const path = require('path');
const app = express()
const xlsx = require('xlsx')


// set the view engine to ejs
app.set('view engine', 'ejs');

app.use(express.static(path.join(__dirname, '/public')));
app.set('views', path.join(__dirname, '/public/views'));

app.get('/', function (req, res) {
    var drinks = [
        { name: 'Bloody Mary', drunkness: 3 },
        { name: 'Martini', drunkness: 5 },
        { name: 'Scotch', drunkness: 10 }
    ];
    var tagline = "Any code of your own that you haven't looked at for six or more months might as well have been written by someone else.";

    
var workbook = xlsx.readFile('Master.xlsx');
var sheet_name_list = workbook.SheetNames;
var xlData = xlsx.utils.sheet_to_json(workbook.Sheets[sheet_name_list[0]]);
console.log(xlData);


    res.render('pages/index', {
        drinks: drinks,
        tagline: tagline
    });
});
app.get('/about', function (req, res) {
    res.render('pages/about', {});
});
app.listen(3000, () => console.log('Example app listening on port 3000!'))