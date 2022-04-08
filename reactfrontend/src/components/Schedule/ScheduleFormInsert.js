import React, { useContext, useState } from "react";
import {
  Text,
  Flex,
  Box,
  FormControl,
  FormLabel,
  Input,
  Button,
  NumberInput,
  NumberInputField,
  NumberInputStepper,
  NumberIncrementStepper,
  NumberDecrementStepper,
} from "@chakra-ui/react";

const form = {
  Name: "",
  Description: "",
  StartTimeHours: Number,
  StartTimeMinutes: Number,
  EndTimeHours: Number,
  EndTimeMinutes: Number,
};

const ScheduleFormInsert = ({
  managementEntityId,
  updateScheduleData,
  graphScheduleData,
}) => {
  const [scheduleData, setScheduleData] = useState({ ...form });
  const handleSubmit = (event) => {
    let startTime = new Date();
    let endTime = new Date();
    startTime.setHours(scheduleData.StartTimeHours);
    startTime.setMinutes(scheduleData.StartTimeMinutes);
    endTime.setHours(scheduleData.EndTimeHours);
    endTime.setMinutes(scheduleData.EndTimeMinutes);

    let fetchObject = {
      ManagementEntityId: managementEntityId,
      Name: scheduleData.Name,
      Description: scheduleData.Description,
      StartTime: startTime.toISOString(),
      EndTime: endTime.toISOString(),
    };
    console.log(fetchObject);
    fetch("api/schedule", {
      method: "POST",
      headers: {
        Authorization: window.sessionStorage.getItem("token"),
        "Content-type": "application/json",
      },
      body: JSON.stringify(fetchObject),
    })
      .then((response) => response.json())
      .then((data) => {
        console.log(data);
        fetchObject.timeScheduleId = data.timeScheduleId;
        setScheduleData({ ...form });
        let tempArray = graphScheduleData;
        tempArray.push(fetchObject);
        updateScheduleData(tempArray);
      });
  };
  return (
    <>
      <Flex mt="5" width="full" justifyContent="end" alignItems="top">
        <Box
          p="8"
          maxWidth="1000px"
          borderWidth="1"
          borderRadius="12"
          boxShadow="lg"
        >
          <Box textAlign="center">
            <Box my="4" textAlign="left"></Box>
            <form onSubmit={handleSubmit}>
              <FormControl isRequired>
                <FormLabel>Name</FormLabel>
                <Input
                  type="text"
                  onChange={(event) =>
                    setScheduleData({
                      ...scheduleData,
                      Name: event.currentTarget.value,
                    })
                  }
                />
              </FormControl>

              <FormControl isRequired>
                <FormLabel>Description</FormLabel>
                <Input
                  type="text"
                  onChange={(event) =>
                    setScheduleData({
                      ...scheduleData,
                      Description: event.currentTarget.value,
                    })
                  }
                />
              </FormControl>
              <Flex>
                <FormControl isRequired>
                  <FormLabel>Start time</FormLabel>
                  <Flex>
                    <NumberInput
                      min="0"
                      max="23"
                      step={1}
                      px="0"
                      w="30%"
                      onChange={(value) =>
                        setScheduleData({
                          ...scheduleData,
                          StartTimeHours: value,
                        })
                      }
                    >
                      <NumberInputField />
                      <NumberInputStepper>
                        <NumberIncrementStepper />
                        <NumberDecrementStepper />
                      </NumberInputStepper>
                    </NumberInput>
                    <Text mx="5px" fontSize="xl">
                      :
                    </Text>
                    <NumberInput
                      min="0"
                      max="59"
                      step={5}
                      px="0"
                      w="30%"
                      onChange={(value) =>
                        setScheduleData({
                          ...scheduleData,
                          StartTimeMinutes: value,
                        })
                      }
                    >
                      <NumberInputField />
                      <NumberInputStepper>
                        <NumberIncrementStepper />
                        <NumberDecrementStepper />
                      </NumberInputStepper>
                    </NumberInput>
                  </Flex>
                </FormControl>
              </Flex>
              <Flex>
                <FormControl isRequired>
                  <FormLabel>End time</FormLabel>
                  <Flex>
                    <NumberInput
                      min="0"
                      max="23"
                      step={1}
                      px="0"
                      w="30%"
                      onChange={(value) =>
                        setScheduleData({
                          ...scheduleData,
                          EndTimeHours: value,
                        })
                      }
                    >
                      <NumberInputField />
                      <NumberInputStepper>
                        <NumberIncrementStepper />
                        <NumberDecrementStepper />
                      </NumberInputStepper>
                    </NumberInput>
                    <Text mx="5px" fontSize="xl">
                      :
                    </Text>
                    <NumberInput
                      min="0"
                      max="59"
                      step={5}
                      px="0"
                      w="30%"
                      onChange={(value) =>
                        setScheduleData({
                          ...scheduleData,
                          EndTimeMinutes: value,
                        })
                      }
                    >
                      <NumberInputField />
                      <NumberInputStepper>
                        <NumberIncrementStepper />
                        <NumberDecrementStepper />
                      </NumberInputStepper>
                    </NumberInput>
                  </Flex>
                </FormControl>
              </Flex>
              <Button width="full" mt={4} type="submit">
                Insert
              </Button>
            </form>
          </Box>
        </Box>
      </Flex>
    </>
  );
};

export default ScheduleFormInsert;
