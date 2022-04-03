function orders(product, qty) {
    let price = getPrice(product)
    let total = qty * price;
    console.log(total.toFixed(2));

    function getPrice(product) {
        switch (product) {
            case 'coffee':
                return 1.50;
            case 'water':
                return 1.00;
            case 'coke':
                return 1.40;
            case 'snacks':
                return 2.00;
        } 
    }
}
orders('water', 5);
orders('coffee', 2);
