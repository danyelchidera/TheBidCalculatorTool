<template>
  <div id="app">
    <h1>Vehicle Price Calculator</h1>
    <form @submit.prevent="calculateTotalPrice">
      <div>
        <label for="basePrice">Base Price:</label>
        <input type="number" v-model="basePrice" id="basePrice" required />
      </div>
      <div>
        <label for="vehicleType">Vehicle Type:</label>
        <select v-model="vehicleType" id="vehicleType" required>
          <option value="Common">Common</option>
          <option value="Luxury">Luxury</option>
        </select>
      </div>
      <button type="submit">Calculate</button>
    </form>
    <div v-if="errorMessage" class="error-message">
      {{ errorMessage }}
    </div>
    <div v-if="fees.length > 0">
      <h2>Fees</h2>
      <ul>
        <li v-for="fee in fees" :key="fee.vehicleFeeType">
          {{ fee.vehicleFeeType }}: {{ formatCurrency(fee.amount) }}
        </li>
      </ul>
      <h2>Total Price: {{ formatCurrency(totalPrice) }}</h2>
    </div>
  </div>
</template>

<script>
import { ref, watch } from 'vue';
import axios from 'axios';

export default {
  name: 'App',
  setup() {
    const basePrice = ref(3009);
    const vehicleType = ref('Common');
    const fees = ref([]);
    const totalPrice = ref(0);
    const errorMessage = ref('');

    const calculateTotalPrice = async () => {
      if (basePrice.value <= 0) {
        errorMessage.value = 'Base price must be greater than zero.';
        fees.value = [];
        totalPrice.value = 0;
        return;
      }

      try {
        const response = await axios.get(`https://localhost:7001/Vehicle/calculate-total-price`, {
          params: {
            VehicleType: vehicleType.value,
            BasePrice: basePrice.value
          }
        });
        fees.value = response.data.fees;
        totalPrice.value = response.data.totalPrice;
        errorMessage.value = ''; // Clear any previous error messages
      } catch (error) {
        if (error.response && error.response.status === 400) {
          const errorData = error.response.data;
          if (errorData.errors && errorData.errors["400"]) {
            errorMessage.value = errorData.errors["400"].join(', ');
          } else {
            errorMessage.value = 'Bad Request: ' + errorData.title;
          }
        } else {
          errorMessage.value = 'An error occurred while calculating the total price.';
        }
        fees.value = [];
        totalPrice.value = 0;
      }
    };

    const formatCurrency = (amount) => {
      return `$${amount.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,')}`;
    };

    watch([basePrice, vehicleType], () => {
      calculateTotalPrice();
    });

    return {
      basePrice,
      vehicleType,
      fees,
      totalPrice,
      errorMessage,
      calculateTotalPrice,
      formatCurrency
    };
  }
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}

form {
  margin-bottom: 20px;
}

label {
  margin-right: 10px;
}

input,
select {
  margin-bottom: 10px;
}

.error-message {
  color: red;
  margin-top: 10px;
}
</style>
