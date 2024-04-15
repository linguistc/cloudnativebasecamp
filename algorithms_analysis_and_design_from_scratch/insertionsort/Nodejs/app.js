'use strict';

function insertionsort(array) {
    for (var i = 1; i < array.length; ++i) {
        var key = array[i];
        for (var j = i - 1; j >= 0; --j) {
            if (array[j] > key) array[j + 1] = array[j];
            else break;
        }
        array[j + 1] = key;
    }
    console.log(array);
}

insertionsort([1, 4, 2, 29, 10, 7]);